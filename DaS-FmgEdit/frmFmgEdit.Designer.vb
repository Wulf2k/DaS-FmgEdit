<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FmgEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtFMGfile = New System.Windows.Forms.TextBox()
        Me.lblGAFile = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.dgvTextEntries = New System.Windows.Forms.DataGridView()
        Me.lblVer = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        CType(Me.dgvTextEntries,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtFMGfile
        '
        Me.txtFMGfile.AllowDrop = true
        Me.txtFMGfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.txtFMGfile.Location = New System.Drawing.Point(64, 12)
        Me.txtFMGfile.Name = "txtFMGfile"
        Me.txtFMGfile.ReadOnly = true
        Me.txtFMGfile.Size = New System.Drawing.Size(554, 20)
        Me.txtFMGfile.TabIndex = 31
        Me.txtFMGfile.Text = "Drag 'n Drop FMG file here"
        Me.txtFMGfile.WordWrap = false
        '
        'lblGAFile
        '
        Me.lblGAFile.AutoSize = true
        Me.lblGAFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGAFile.Location = New System.Drawing.Point(8, 15)
        Me.lblGAFile.Name = "lblGAFile"
        Me.lblGAFile.Size = New System.Drawing.Size(52, 13)
        Me.lblGAFile.TabIndex = 32
        Me.lblGAFile.Text = "FMG File:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(621, 38)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(543, 38)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 33
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = true
        '
        'dgvTextEntries
        '
        Me.dgvTextEntries.AllowUserToAddRows = false
        Me.dgvTextEntries.AllowUserToDeleteRows = false
        Me.dgvTextEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.dgvTextEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTextEntries.Location = New System.Drawing.Point(11, 67)
        Me.dgvTextEntries.Name = "dgvTextEntries"
        Me.dgvTextEntries.Size = New System.Drawing.Size(685, 525)
        Me.dgvTextEntries.TabIndex = 37
        '
        'lblVer
        '
        Me.lblVer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.lblVer.AutoSize = true
        Me.lblVer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVer.Location = New System.Drawing.Point(459, 43)
        Me.lblVer.Name = "lblVer"
        Me.lblVer.Size = New System.Drawing.Size(76, 13)
        Me.lblVer.TabIndex = 38
        Me.lblVer.Text = "2016.10.25.22"
        '
        'btnBrowse
        '
        Me.btnBrowse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnBrowse.Location = New System.Drawing.Point(621, 10)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 39
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = true
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(12, 38)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(182, 23)
        Me.btnUpdate.TabIndex = 76
        Me.btnUpdate.Text = "Update FMG Editor"
        Me.btnUpdate.UseVisualStyleBackColor = true
        Me.btnUpdate.Visible = false
        '
        'FmgEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 604)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.lblVer)
        Me.Controls.Add(Me.dgvTextEntries)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtFMGfile)
        Me.Controls.Add(Me.lblGAFile)
        Me.Name = "FmgEdit"
        Me.Text = "Wulf's FMG Editor"
        CType(Me.dgvTextEntries,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents txtFMGfile As TextBox
    Friend WithEvents lblGAFile As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents dgvTextEntries As DataGridView
    Friend WithEvents lblVer As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnUpdate As Button
End Class
