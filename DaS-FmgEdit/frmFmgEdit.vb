Imports System.IO
Imports System.Threading


Public Class FmgEdit
    Shared bigendian = False
    Shared fs As FileStream

    Shared Version As String
    Shared VersionCheckUrl As String = "http://wulf2k.ca/souls/FmgEdit-ver.txt"


    Private Async Sub updatecheck()
        Try
            Dim client As New Net.WebClient()
            Dim content As String = Await client.DownloadStringTaskAsync(VersionCheckUrl)

            Dim lines() As String = content.Split({vbCrLf, vbLf}, StringSplitOptions.None)
            Dim latestVersion = lines(0)
            Dim latestUrl = lines(1)

            If latestVersion > Version.Replace(".", "") Then
                btnUpdate.Tag = latestUrl
                btnUpdate.Visible = True
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        dgvTextEntries.Rows.Clear()
        dgvTextEntries.Columns.Clear()

        dgvTextEntries.Columns.Add("ID", "ID")
        dgvTextEntries.Columns.Add("Text", "Text")

        dgvTextEntries.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTextEntries.Columns("Text").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTextEntries.Columns("Text").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dgvTextEntries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        fs = File.Open(txtFMGfile.Text, FileMode.Open)

        bigendian = (RInt8(9) = -1)

        Dim numEntries As Integer
        Dim startOffset As Integer


        numEntries = RInt32(&HC)
        startOffset = RInt32(&H14)


        For i = 0 To numEntries - 1
            Dim startIndex As Integer
            Dim startID As Integer
            Dim endID As Integer
            Dim txtOffset As Integer
            Dim txt As String

            startIndex = RInt32(&H1C + i * &HC)
            startID = RInt32(&H1C + i * &HC + 4)
            endID = RInt32(&H1C + i * &HC + 8)

            For j = 0 To (endID - startID)
                txtOffset = RInt32(startOffset + ((startIndex + j) * 4))

                txt = ""
                If txtOffset > 0 Then
                    txt = RUniString(txtOffset)
                    txt = txt.Replace(Chr(10), "/n/")
                End If

                dgvTextEntries.Rows.Add({j + startID, txt})
            Next
        Next

        fs.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Not File.Exists(txtFMGfile.Text & ".bak") Then
                File.Copy(txtFMGfile.Text, txtFMGfile.Text & ".bak")
            End If

            fs = File.Open(txtFMGfile.Text, FileMode.Create)

            Dim numEntries As Integer = 0
            Dim startOffset As Integer = 0
            Dim txtOffset As Integer = 0

            Dim prevID As Integer = -2
            Dim numChunks As Integer = 0

            For i = 0 To dgvTextEntries.Rows.Count - 1
                If dgvTextEntries.Rows(i).Cells("ID").FormattedValue > (prevID + 1) Then
                    numChunks += 1
                End If

                numEntries += 1
                prevID = dgvTextEntries.Rows(i).Cells("ID").FormattedValue
            Next


            startOffset = &H1C + &HC * numChunks
            txtOffset = startOffset + numEntries * 4

            Dim FirstID As Integer = dgvTextEntries.Rows(0).Cells("ID").FormattedValue
            Dim LastID As Integer = FirstID
            Dim str As String
            Dim startEntry As Integer = 0

            numEntries = 0
            numChunks = 0
            For i = 0 To dgvTextEntries.Rows.Count - 1
                If dgvTextEntries.Rows(i).Cells("ID").FormattedValue > (LastID + 1) Then
                    WInt32(&H1C + numChunks * &HC, startEntry)
                    WInt32(&H1C + numChunks * &HC + 4, FirstID)
                    WInt32(&H1C + numChunks * &HC + 8, LastID)

                    FirstID = dgvTextEntries.Rows(i).Cells("ID").FormattedValue
                    startEntry = numEntries
                    numChunks += 1
                End If

                str = dgvTextEntries.Rows(i).Cells("Text").FormattedValue

                If Not str = "" Then
                    WInt32(startOffset + numEntries * 4, txtOffset)

                    str = str.Replace("/n/", ChrW(10))

                    If Not str(str.Length - 1) = ChrW(0) Then
                        str = str & ChrW(0)
                    End If

                    WUniString(txtOffset, str)
                    txtOffset += str.Length * 2
                End If


                numEntries += 1
                LastID = dgvTextEntries.Rows(i).Cells("ID").FormattedValue
            Next

            If fs.Length Mod 4 = 2 Then WInt16(txtOffset, 0)

            WInt32(&H1C + numChunks * &HC, startEntry)
            WInt32(&H1C + numChunks * &HC + 4, FirstID)
            WInt32(&H1C + numChunks * &HC + 8, LastID)

            WInt32(0, &H10000)
            WInt8(&H8, 1)
            If bigendian Then WInt8(&H9, -1)
            WInt32(&H4, fs.Length)
            WInt32(&HC, numChunks + 1)
            WInt32(&H10, numEntries)
            WInt32(&H14, startOffset)

            fs.Close()

            MsgBox("File saved.")

        Catch ex As Exception
            MsgBox("Unknown error." & Environment.NewLine & ex.Message)
        End Try
    End Sub


    Private Sub txt_Drop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtFMGfile.DragDrop
        Dim file() As String = e.Data.GetData(DataFormats.FileDrop)
        sender.Text = file(0)
    End Sub
    Private Sub txt_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtFMGfile.DragEnter
        Dim file() As String = e.Data.GetData(DataFormats.FileDrop)
        If Not (New FileInfo(file(0)).Extension.ToUpper().Equals(".FMG")) Then
            e.Effect = DragDropEffects.None
            Return
        End If
        e.Effect = DragDropEffects.Copy
    End Sub



    Private Function RInt8(ByVal loc As Integer) As SByte
        Dim tmpInt8 As SByte
        Dim byt(0) As Byte

        fs.Position = loc
        fs.Read(byt, 0, 1)

        tmpInt8 = CSByte(byt(0))

        Return tmpInt8
    End Function
    Private Function RInt32(ByVal loc As Integer) As Int32
        Dim tmpInt32 As Integer = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc
        fs.Read(byt, 0, 4)

        If bigendian Then
            Array.Reverse(byt)
        End If

        tmpInt32 = BitConverter.ToInt32(byt, 0)

        Return tmpInt32
    End Function
    Private Function RUInt32(ByVal loc As Integer) As UInt32
        Dim tmpUInt32 As UInt32 = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc
        fs.Read(byt, 0, 4)

        If bigendian Then
            Array.Reverse(byt)
        End If

        tmpUInt32 = BitConverter.ToUInt32(byt, 0)

        Return tmpUInt32
    End Function
    Private Function RUniString(ByVal loc As Integer) As String
        fs.Position = loc

        Dim tmpStr As String = ""
        Dim endstr As Boolean = False
        Dim byt(1) As Byte
        Dim chara As Char

        While Not endstr
            fs.Read(byt, 0, 2)

            If bigendian Then
                Array.Reverse(byt)
            End If

            chara = System.Text.Encoding.Unicode.GetString(byt)(0)
            If chara = Chr(0) Then
                endstr = True

            Else
                tmpStr = tmpStr & chara
            End If


        End While

        Return tmpStr
    End Function

    Private Sub WInt8(ByVal loc As Integer, ByVal val As SByte)
        fs.Position = loc
        fs.Write({CByte(val)}, 0, 1)
    End Sub
    Private Sub WInt16(ByVal loc As Integer, ByVal val As Int16)
        fs.Position = loc
        Dim byt(1) As Byte
        byt = BitConverter.GetBytes(val)

        If bigendian Then
            Array.Reverse(byt)
        End If

        fs.Write(byt, 0, 2)
    End Sub
    Private Sub WInt32(ByVal loc As Integer, ByVal val As Int32)
        fs.Position = loc
        Dim byt(3) As Byte

        byt = BitConverter.GetBytes(val)

        If bigendian Then
            Array.Reverse(byt)
        End If

        fs.Write(byt, 0, 4)
    End Sub
    Private Sub WUniString(ByVal loc As Integer, ByRef str As String)
        fs.Position = loc

        Dim byt(1) As Byte
        Dim chara As Char

        For i = 0 To str.Length - 1
            chara = str(i)
            byt = BitConverter.GetBytes(chara)

            If bigendian Then
                Array.Reverse(byt)
            End If

            fs.Write(byt, 0, 2)
        Next
    End Sub

    Private Sub WBytes(ByVal loc As Integer, ByVal byt() As Byte)
        fs.Position = loc
        fs.Write(byt, 0, byt.Length)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim openDlg As New OpenFileDialog()

        openDlg.Filter = "FMG File|*.FMG"
        openDlg.Title = "Open your FMG file"

        If openDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtFMGfile.Text = openDlg.FileName
        End If
    End Sub

    Private Sub FmgEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Version = lblVer.Text

        Dim oldFileArg As String = Nothing
        For Each arg In Environment.GetCommandLineArgs().Skip(1)
            If arg.StartsWith("--old-file=") Then
                oldFileArg = arg.Substring("--old-file=".Length)
            Else
                MsgBox("Unknown command line arguments")
                oldFileArg = Nothing
                Exit For
            End If
        Next
        If oldFileArg IsNot Nothing Then
            If oldFileArg.EndsWith(".old") Then
                Dim t = New Thread(
                    Sub()
                    Try
                        'Give the old version time to shut down
                        Thread.Sleep(1000)
                        File.Delete(oldFileArg)
                    Catch ex As Exception
                        Me.Invoke(Function() MsgBox("Deleting old version failed: " & vbCrLf & ex.Message, MsgBoxStyle.Exclamation))
                    End Try
                End Sub)
                t.Start()
            Else
                MsgBox("Deleting old version failed: Invalid filename ", MsgBoxStyle.Exclamation)
            End If
        End If


        updatecheck()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim updateWindow As New UpdateWindow(sender.tag)
        updateWindow.ShowDialog()
        If updateWindow.WasSuccessful Then
            Process.Start(updateWindow.NewAssembly, """--old-file=" & updateWindow.OldAssembly & """")
            Me.Close()
        End If
    End Sub

    Private Sub btnExportCSV_Click(sender As Object, e As EventArgs) Handles btnExportCSV.Click
        Dim entries as new List(Of String)

        For each row as DataGridViewrow In dgvTextEntries.Rows
            entries.Add((row.cells("ID").FormattedValue & "|" & row.Cells("Text").FormattedValue))
        Next

        File.WriteAllLines(txtFMGfile.Text & ".csv", entries)
        MsgBox("Successfully exported to " & txtFMGfile.Text & ".csv")
    End Sub

    Private Sub btnImportCSV_Click(sender As Object, e As EventArgs) Handles btnImportCSV.Click
        If File.Exists(txtFMGfile.Text & ".csv") Then
            dgvTextEntries.Rows.Clear

            Dim entries = File.ReadAllLines(txtFMGfile.Text & ".csv")
            For each entry In entries
                dgvTextEntries.Rows.Add({entry.Split("|")(0), entry.Split("|")(1)})    
            Next
        Else
            MsgBox(txtFMGfile.Text & ".csv not found.")
        End If
        
    End Sub
End Class
