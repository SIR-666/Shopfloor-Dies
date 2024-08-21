Imports BaiqiSoft.LabelControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemo
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
        Me.components = New System.ComponentModel.Container()
        Me.cboScrollbars = New System.Windows.Forms.ComboBox()
        Me.grpOptions = New System.Windows.Forms.GroupBox()
        Me.btnPrintTemlate = New System.Windows.Forms.Button()
        Me.btnBackgroundPrinting = New System.Windows.Forms.Button()
        Me.chkReadOnly = New System.Windows.Forms.CheckBox()
        Me.lblScrollbars = New System.Windows.Forms.Label()
        Me.chkShowRuler = New System.Windows.Forms.CheckBox()
        Me.chkShowStatusStrip = New System.Windows.Forms.CheckBox()
        Me.chkShowRightPanel = New System.Windows.Forms.CheckBox()
        Me.chkShowFormattingToolStrip = New System.Windows.Forms.CheckBox()
        Me.chkShowToolbox = New System.Windows.Forms.CheckBox()
        Me.chkShowStandardToolStrip = New System.Windows.Forms.CheckBox()
        Me.chkShowMenuStrip = New System.Windows.Forms.CheckBox()
        Me.LabelDesigner1 = New BaiqiSoft.LabelControl.LabelDesigner()
        Me.grpOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboScrollbars
        '
        Me.cboScrollbars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboScrollbars.FormattingEnabled = True
        Me.cboScrollbars.Items.AddRange(New Object() {"None", "Horizontal", "Vertical", "Both"})
        Me.cboScrollbars.Location = New System.Drawing.Point(16, 251)
        Me.cboScrollbars.Name = "cboScrollbars"
        Me.cboScrollbars.Size = New System.Drawing.Size(127, 21)
        Me.cboScrollbars.TabIndex = 11
        '
        'grpOptions
        '
        Me.grpOptions.Controls.Add(Me.btnPrintTemlate)
        Me.grpOptions.Controls.Add(Me.btnBackgroundPrinting)
        Me.grpOptions.Controls.Add(Me.chkReadOnly)
        Me.grpOptions.Controls.Add(Me.lblScrollbars)
        Me.grpOptions.Controls.Add(Me.cboScrollbars)
        Me.grpOptions.Controls.Add(Me.chkShowRuler)
        Me.grpOptions.Controls.Add(Me.chkShowStatusStrip)
        Me.grpOptions.Controls.Add(Me.chkShowRightPanel)
        Me.grpOptions.Controls.Add(Me.chkShowFormattingToolStrip)
        Me.grpOptions.Controls.Add(Me.chkShowToolbox)
        Me.grpOptions.Controls.Add(Me.chkShowStandardToolStrip)
        Me.grpOptions.Controls.Add(Me.chkShowMenuStrip)
        Me.grpOptions.Location = New System.Drawing.Point(871, 12)
        Me.grpOptions.Name = "grpOptions"
        Me.grpOptions.Size = New System.Drawing.Size(179, 383)
        Me.grpOptions.TabIndex = 12
        Me.grpOptions.TabStop = False
        Me.grpOptions.Text = "Options"
        '
        'btnPrintTemlate
        '
        Me.btnPrintTemlate.Location = New System.Drawing.Point(16, 338)
        Me.btnPrintTemlate.Name = "btnPrintTemlate"
        Me.btnPrintTemlate.Size = New System.Drawing.Size(127, 28)
        Me.btnPrintTemlate.TabIndex = 14
        Me.btnPrintTemlate.Text = "Print Template"
        Me.btnPrintTemlate.UseVisualStyleBackColor = True
        '
        'btnBackgroundPrinting
        '
        Me.btnBackgroundPrinting.Location = New System.Drawing.Point(16, 291)
        Me.btnBackgroundPrinting.Name = "btnBackgroundPrinting"
        Me.btnBackgroundPrinting.Size = New System.Drawing.Size(127, 28)
        Me.btnBackgroundPrinting.TabIndex = 13
        Me.btnBackgroundPrinting.Text = "Background printing"
        Me.btnBackgroundPrinting.UseVisualStyleBackColor = True
        '
        'chkReadOnly
        '
        Me.chkReadOnly.AutoSize = True
        Me.chkReadOnly.Location = New System.Drawing.Point(19, 200)
        Me.chkReadOnly.Name = "chkReadOnly"
        Me.chkReadOnly.Size = New System.Drawing.Size(73, 17)
        Me.chkReadOnly.TabIndex = 12
        Me.chkReadOnly.Text = "ReadOnly"
        Me.chkReadOnly.UseVisualStyleBackColor = True
        '
        'lblScrollbars
        '
        Me.lblScrollbars.AutoSize = True
        Me.lblScrollbars.Location = New System.Drawing.Point(16, 235)
        Me.lblScrollbars.Name = "lblScrollbars"
        Me.lblScrollbars.Size = New System.Drawing.Size(86, 13)
        Me.lblScrollbars.TabIndex = 7
        Me.lblScrollbars.Text = "Show Scrollbars:"
        '
        'chkShowRuler
        '
        Me.chkShowRuler.AutoSize = True
        Me.chkShowRuler.Checked = True
        Me.chkShowRuler.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowRuler.Location = New System.Drawing.Point(19, 177)
        Me.chkShowRuler.Name = "chkShowRuler"
        Me.chkShowRuler.Size = New System.Drawing.Size(78, 17)
        Me.chkShowRuler.TabIndex = 6
        Me.chkShowRuler.Text = "ShowRuler"
        Me.chkShowRuler.UseVisualStyleBackColor = True
        '
        'chkShowStatusStrip
        '
        Me.chkShowStatusStrip.AutoSize = True
        Me.chkShowStatusStrip.Checked = True
        Me.chkShowStatusStrip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowStatusStrip.Location = New System.Drawing.Point(19, 154)
        Me.chkShowStatusStrip.Name = "chkShowStatusStrip"
        Me.chkShowStatusStrip.Size = New System.Drawing.Size(104, 17)
        Me.chkShowStatusStrip.TabIndex = 5
        Me.chkShowStatusStrip.Text = "ShowStatusStrip"
        Me.chkShowStatusStrip.UseVisualStyleBackColor = True
        '
        'chkShowRightPanel
        '
        Me.chkShowRightPanel.AutoSize = True
        Me.chkShowRightPanel.Checked = True
        Me.chkShowRightPanel.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowRightPanel.Location = New System.Drawing.Point(19, 131)
        Me.chkShowRightPanel.Name = "chkShowRightPanel"
        Me.chkShowRightPanel.Size = New System.Drawing.Size(105, 17)
        Me.chkShowRightPanel.TabIndex = 4
        Me.chkShowRightPanel.Text = "ShowRightPanel"
        Me.chkShowRightPanel.UseVisualStyleBackColor = True
        '
        'chkShowFormattingToolStrip
        '
        Me.chkShowFormattingToolStrip.AutoSize = True
        Me.chkShowFormattingToolStrip.Checked = True
        Me.chkShowFormattingToolStrip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowFormattingToolStrip.Location = New System.Drawing.Point(19, 85)
        Me.chkShowFormattingToolStrip.Name = "chkShowFormattingToolStrip"
        Me.chkShowFormattingToolStrip.Size = New System.Drawing.Size(144, 17)
        Me.chkShowFormattingToolStrip.TabIndex = 3
        Me.chkShowFormattingToolStrip.Text = "ShowFormattingToolStrip"
        Me.chkShowFormattingToolStrip.UseVisualStyleBackColor = True
        '
        'chkShowToolbox
        '
        Me.chkShowToolbox.AutoSize = True
        Me.chkShowToolbox.Checked = True
        Me.chkShowToolbox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowToolbox.Location = New System.Drawing.Point(19, 108)
        Me.chkShowToolbox.Name = "chkShowToolbox"
        Me.chkShowToolbox.Size = New System.Drawing.Size(91, 17)
        Me.chkShowToolbox.TabIndex = 2
        Me.chkShowToolbox.Text = "ShowToolbox"
        Me.chkShowToolbox.UseVisualStyleBackColor = True
        '
        'chkShowStandardToolStrip
        '
        Me.chkShowStandardToolStrip.AutoSize = True
        Me.chkShowStandardToolStrip.Checked = True
        Me.chkShowStandardToolStrip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowStandardToolStrip.Location = New System.Drawing.Point(19, 62)
        Me.chkShowStandardToolStrip.Name = "chkShowStandardToolStrip"
        Me.chkShowStandardToolStrip.Size = New System.Drawing.Size(138, 17)
        Me.chkShowStandardToolStrip.TabIndex = 1
        Me.chkShowStandardToolStrip.Text = "ShowStandardToolStrip"
        Me.chkShowStandardToolStrip.UseVisualStyleBackColor = True
        '
        'chkShowMenuStrip
        '
        Me.chkShowMenuStrip.AutoSize = True
        Me.chkShowMenuStrip.Checked = True
        Me.chkShowMenuStrip.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMenuStrip.Location = New System.Drawing.Point(19, 38)
        Me.chkShowMenuStrip.Name = "chkShowMenuStrip"
        Me.chkShowMenuStrip.Size = New System.Drawing.Size(101, 17)
        Me.chkShowMenuStrip.TabIndex = 0
        Me.chkShowMenuStrip.Text = "ShowMenuStrip"
        Me.chkShowMenuStrip.UseVisualStyleBackColor = True
        '
        'LabelDesigner1
        '
        Me.LabelDesigner1.Location = New System.Drawing.Point(0, 0)
        Me.LabelDesigner1.Name = "LabelDesigner1"
        Me.LabelDesigner1.Size = New System.Drawing.Size(865, 600)
        Me.LabelDesigner1.TabIndex = 0
        '
        'frmDemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 601)
        Me.Controls.Add(Me.grpOptions)
        Me.Controls.Add(Me.LabelDesigner1)
        Me.Name = "frmDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MstLabel Control Demo"
        Me.grpOptions.ResumeLayout(False)
        Me.grpOptions.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LabelDesigner1 As LabelDesigner
    Friend WithEvents cboScrollbars As System.Windows.Forms.ComboBox
    Friend WithEvents grpOptions As System.Windows.Forms.GroupBox
    Friend WithEvents chkShowMenuStrip As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowStandardToolStrip As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowFormattingToolStrip As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowToolbox As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowRightPanel As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowStatusStrip As System.Windows.Forms.CheckBox
    Friend WithEvents chkShowRuler As System.Windows.Forms.CheckBox
    Friend WithEvents lblScrollbars As System.Windows.Forms.Label
    Friend WithEvents chkReadOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnBackgroundPrinting As System.Windows.Forms.Button
    Friend WithEvents btnPrintTemlate As System.Windows.Forms.Button

End Class
