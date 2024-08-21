Imports System.Drawing.Printing
Imports System.Data
Imports System.IO
Imports BaiqiSoft.LabelControl


Public Class frmDemo
    Private m_DataTable As DataTable


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Enter your license key here
        LabelDesigner1.LicenseKey = ""
        '
        'LabelDesigner1.LanguageConfig = Application.StartupPath & "\Language.ini"
        '
        Dim mnuHelp As New ToolStripMenuItem("&Help")
        LabelDesigner1.MenuStrip.Items.Add(mnuHelp)
        Dim mnuHomePage As New ToolStripMenuItem("Home Page", Nothing, New EventHandler(AddressOf mnuHomePage_Click))
        mnuHelp.DropDownItems.Add(mnuHomePage)
        Dim mnuS1 As New ToolStripSeparator
        mnuHelp.DropDownItems.Add(mnuS1)
        Dim mnuAbout As New ToolStripMenuItem("About...", Nothing, New EventHandler(AddressOf mnuAbout_Click))
        mnuHelp.DropDownItems.Add(mnuAbout)

        CreateDataTable()

        LabelDesigner1.TableNames.Clear()
        LabelDesigner1.TableNames.Add("Product")
        LabelDesigner1.RefreshPropertiesPanel()

        'LabelDesigner1.MenuItems.NewLabel.Visible = False
        'LabelDesigner1.ToolbarButtons.NewLabel.Visible = False

        frmDemo_Resize(Me, EventArgs.Empty)
    End Sub

    Private Sub mnuHomePage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start("http://www.mysofttool.com")
    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LabelDesigner1.AboutBox()
    End Sub

    Private Sub LabelDesigner1_ButtonClick(sender As Object, e As ButtonClickEventArgs) Handles LabelDesigner1.ButtonClick
        If e.Button = Buttons.Exit Then
            e.Handled = True
            Me.Close()
        End If
    End Sub

    Private Sub LabelDesigner1_PictureLibraryInitializing(sender As Object, e As PictureLibraryInitializingEventArgs) Handles LabelDesigner1.PictureLibraryInitializing
        Dim sPath As String = Application.StartupPath & "\Clipart"
        Dim fileList() As String
        Try
            fileList = Directory.GetFiles(sPath)
        Catch ex As Exception
            Return
        End Try
        For Each filename As String In fileList
            e.AddImage(Path.GetFileNameWithoutExtension(filename), filename)
        Next
    End Sub

    Private Sub LabelDesigner1_SelectedTableChanged(sender As Object, e As System.EventArgs) Handles LabelDesigner1.SelectedTableChanged
        Select Case LabelDesigner1.Label.DataTable
            Case "Product"
                LabelDesigner1.DataSource = m_DataTable
                LabelDesigner1.ColumnNames.Clear()
                LabelDesigner1.ColumnNames.Add("ProductName")
                LabelDesigner1.ColumnNames.Add("Barcode")
                LabelDesigner1.ColumnNames.Add("Price")
                LabelDesigner1.ColumnNames.Add("LabelNumber")
            Case Else
                LabelDesigner1.DataSource = Nothing
                LabelDesigner1.ColumnNames.Clear()
        End Select
    End Sub

    Private Sub CreateDataTable()
        If m_DataTable IsNot Nothing Then Return
        m_DataTable = New DataTable
        'Columns
        m_DataTable.Columns.Add("ProductName", GetType(String))
        m_DataTable.Columns.Add("Barcode", GetType(String))
        m_DataTable.Columns.Add("Price", GetType(Single))
        m_DataTable.Columns.Add("LabelNumber", GetType(Integer))
        'Rows
        m_DataTable.Rows.Add("Mishi Kobe Niku", "845723054943", 96.0, 2)
        m_DataTable.Rows.Add("Carnarvon Tigers", "246321456231", 61.5, 1)
        m_DataTable.Rows.Add("Ipoh Coffee", "589412354786", 46.0, 3)
        m_DataTable.Rows.Add("Aniseed Syrup", "457125463254", 10.0, 1)
        m_DataTable.Rows.Add("Teatime Chocolate Biscuits", "232145674321", 9.2, 5)
    End Sub

    Private Sub frmDemo_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        grpOptions.Left = ClientSize.Width - 8 - grpOptions.Width
        LabelDesigner1.Width = grpOptions.Left - 8
        LabelDesigner1.Height = ClientSize.Height
    End Sub

    Private Sub chkShowMenuStrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowMenuStrip.CheckedChanged
        LabelDesigner1.ShowMenuStrip = chkShowMenuStrip.Checked
    End Sub

    Private Sub chkShowStandardToolStrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowStandardToolStrip.CheckedChanged
        LabelDesigner1.ShowStandardToolStrip = chkShowStandardToolStrip.Checked
    End Sub

    Private Sub chkShowFormattingToolStrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowFormattingToolStrip.CheckedChanged
        LabelDesigner1.ShowFormattingToolStrip = chkShowFormattingToolStrip.Checked
    End Sub

    Private Sub chkShowToolbox_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowToolbox.CheckedChanged
        LabelDesigner1.ShowToolbox = chkShowToolbox.Checked
    End Sub

    Private Sub chkShowRightPanel_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowRightPanel.CheckedChanged
        LabelDesigner1.ShowRightPanel = chkShowRightPanel.Checked
    End Sub

    Private Sub chkShowStatusStrip_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowStatusStrip.CheckedChanged
        LabelDesigner1.ShowStatusStrip = chkShowStatusStrip.Checked
    End Sub

    Private Sub chkShowRuler_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkShowRuler.CheckedChanged
        LabelDesigner1.ShowRuler = chkShowRuler.Checked
    End Sub

    Private Sub cboScrollbars_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboScrollbars.SelectedIndexChanged
        LabelDesigner1.ScrollBars = cboScrollbars.SelectedIndex
    End Sub

    Private Sub chkReadOnly_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkReadOnly.CheckedChanged
        LabelDesigner1.ReadOnly = chkReadOnly.Checked
    End Sub

    Private Sub btnBackgroundPrinting_Click(sender As System.Object, e As System.EventArgs) Handles btnBackgroundPrinting.Click

        'Unlike LabelDesigner class, the LabelPrinting class does not have a user interface.
        'It will greatly improves performance when you only need to print in the background on the production machine.

        Dim newLabel As New LabelPrinting(True)
        newLabel.LicenseKey = ""

        newLabel.BeginUpdate()

        'Label properties
        newLabel.Label.Width = 80    'default unit is mm
        newLabel.Label.Height = 50   'mm

        'Page setup
        newLabel.PageSetup.PaperSize.RawKind = PaperKind.Custom
        newLabel.PageSetup.PaperWidth = 80    'default unit is mm
        newLabel.PageSetup.PaperHeight = 50   'mm

        'Add objects
        Dim text As New Text
        text.Location = New PointF(22, 10.5)
        text.Size = New SizeF(36, 7.7)
        text.DataType = DataType.DataTable
        text.DataColumn = "ProductName"
        newLabel.Items.Add(text)

        Dim barcode As New Barcode
        barcode.Location = New PointF(14, 25.1)
        barcode.Size = New SizeF(52.1, 16.4)
        barcode.DataType = DataType.DataTable
        barcode.DataColumn = "Barcode"
        newLabel.Items.Add(barcode)

        newLabel.EndUpdate()

        newLabel.DataSource = m_DataTable
        newLabel.PrintOptions.Quantity = QuantityOptions.AllRecords

        newLabel.PrintPreview(False)
        'newLabel.PrintOut(False)
    End Sub

    Private Sub btnPrintTemlate_Click(sender As System.Object, e As System.EventArgs) Handles btnPrintTemlate.Click

        'Unlike LabelDesigner class, the LabelPrinting class does not have a user interface.
        'It will greatly improves performance when you only need to print in the background on the production machine.

        Dim theLabel As New LabelPrinting
        theLabel.LicenseKey = ""

        theLabel.OpenLabel(Application.StartupPath & "\test.blf")

        theLabel.DataSource = m_DataTable

        theLabel.PrintOptions.Quantity = QuantityOptions.SelectedRecords
        theLabel.PrintOptions.RecordsFrom = 1
        theLabel.PrintOptions.RecordsTo = 5

        theLabel.PrintPreview(True)
        'theLabel.PrintOut(False)
    End Sub
End Class
