Imports System.IO

Public Class frmDaSFmgEdit
    Shared bigendian = False



    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        dgvTextEntries.Rows.Clear()
        dgvTextEntries.Columns.Clear()

        dgvTextEntries.Columns.Add("ID", "ID")
        dgvTextEntries.Columns.Add("Text", "Text")

        dgvTextEntries.Columns("ID").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTextEntries.Columns("Text").AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        dgvTextEntries.Columns("Text").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        dgvTextEntries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells




        Dim FMGstream = File.Open(txtFMGfile.Text, FileMode.Open)

        Dim numEntries As Integer
        Dim startOffset As Integer


        numEntries = UInt32FromStream(FMGstream, &HC)
        startOffset = UInt32FromStream(FMGstream, &H14)


        For i = 0 To numEntries - 1
            Dim startIndex As Integer
            Dim startID As Integer
            Dim endID As Integer
            Dim txtOffset As Integer
            Dim txt As String

            startIndex = Int32FromStream(FMGstream, &H1C + i * &HC)
            startID = Int32FromStream(FMGstream, &H1C + i * &HC + 4)
            endID = Int32FromStream(FMGstream, &H1C + i * &HC + 8)

            'MsgBox(startID & " " & endID & " " & i)
            For j = 0 To (endID - startID)
                txtOffset = UInt32FromStream(FMGstream, startOffset + ((startIndex + j) * 4))

                txt = ""
                If txtOffset > 0 Then
                    txt = UniStringFromStream(FMGstream, txtOffset)
                End If
                'UniStringFromStream(FMGstream,
                dgvTextEntries.Rows.Add({j + startID, txt})
            Next

        Next





        FMGstream.Close()
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

    Private Function Int32FromStream(fs As Stream, ByVal loc As Integer) As Integer
        Dim tmpInt As Integer = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc
        fs.Read(byt, 0, 4)

        If bigendian Then
            For i = 0 To 3
                tmpInt += Convert.ToInt32(byt(i)) * &H100 ^ (3 - i)
            Next
        Else
            For i = 0 To 3
                tmpInt += Convert.ToInt32(byt(i)) * &H100 ^ i
            Next
        End If

        Return tmpInt
    End Function
    Private Function UInt32FromStream(fs As Stream, ByVal loc As Integer) As UInteger
        Dim tmpUInt As UInteger = 0
        Dim byt = New Byte() {0, 0, 0, 0}

        fs.Position = loc
        fs.Read(byt, 0, 4)

        If bigendian Then
            For i = 0 To 3
                tmpUInt += Convert.ToUInt32(byt(i)) * &H100 ^ (3 - i)
            Next
        Else
            For i = 0 To 3
                tmpUInt += Convert.ToUInt32(byt(i)) * &H100 ^ i
            Next
        End If

        Return tmpUInt
    End Function
    Private Function UniStringFromStream(fs As Stream, ByVal loc As Integer) As String
        fs.Position = loc

        Dim tmpStr As String = ""
        Dim endstr As Boolean = False
        Dim byt(1) As Byte
        Dim chr As Char

        While Not endstr
            fs.Read(byt, 0, 2)

            If Not bigendian Then
                Array.Reverse(byt)
            End If

            chr = ChrW(byt(0) * 256 + byt(1))
            If chr = ChrW(0) Then endstr = True

            tmpStr = tmpStr & chr
        End While
        Return tmpStr
    End Function

    Private Sub WriteBytes(fs As FileStream, ByVal loc As Integer, ByVal byt() As Byte)
        fs.Position = loc
        fs.Write(byt, 0, byt.Length)
    End Sub
    Private Sub WriteBytesToFile(fileName As String, bytes() As Byte)
        Dim file = New FileStream(fileName, FileMode.OpenOrCreate)
        file.Write(bytes, 0, bytes.Length)
        file.Dispose()
    End Sub
End Class
