﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDaSFmgEdit
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
        CType(Me.dgvTextEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFMGfile
        '
        Me.txtFMGfile.AllowDrop = True
        Me.txtFMGfile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFMGfile.Location = New System.Drawing.Point(64, 12)
        Me.txtFMGfile.Name = "txtFMGfile"
        Me.txtFMGfile.ReadOnly = True
        Me.txtFMGfile.Size = New System.Drawing.Size(632, 20)
        Me.txtFMGfile.TabIndex = 31
        Me.txtFMGfile.Text = "Drag 'n Drop FMG file here"
        Me.txtFMGfile.WordWrap = False
        '
        'lblGAFile
        '
        Me.lblGAFile.AutoSize = True
        Me.lblGAFile.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblGAFile.Location = New System.Drawing.Point(8, 15)
        Me.lblGAFile.Name = "lblGAFile"
        Me.lblGAFile.Size = New System.Drawing.Size(52, 13)
        Me.lblGAFile.TabIndex = 32
        Me.lblGAFile.Text = "FMG File:"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(621, 38)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 34
        Me.btnSave.Text = "Rebuild"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpen.Location = New System.Drawing.Point(543, 38)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 33
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'dgvTextEntries
        '
        Me.dgvTextEntries.AllowUserToAddRows = False
        Me.dgvTextEntries.AllowUserToDeleteRows = False
        Me.dgvTextEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvTextEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTextEntries.Location = New System.Drawing.Point(11, 67)
        Me.dgvTextEntries.Name = "dgvTextEntries"
        Me.dgvTextEntries.Size = New System.Drawing.Size(685, 316)
        Me.dgvTextEntries.TabIndex = 37
        '
        'frmDaSFmgEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 395)
        Me.Controls.Add(Me.dgvTextEntries)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtFMGfile)
        Me.Controls.Add(Me.lblGAFile)
        Me.Name = "frmDaSFmgEdit"
        Me.Text = "Wulf's FMG Editor"
        CType(Me.dgvTextEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtFMGfile As TextBox
    Friend WithEvents lblGAFile As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents dgvTextEntries As DataGridView
End Class