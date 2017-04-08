Imports System.IO
Imports System.Data.SQLite

Public Class frmBTOBirdNameMatch
    Private strG21CommonName As String
    Public Property G21CommonName() As String
        Get
            Return strG21CommonName
        End Get
        Set(ByVal value As String)
            strG21CommonName = value
            lblG21CommonName.Text = value
            InitValues()
        End Set
    End Property

    Private strG21ScientificName As String
    Public Property G21ScientificName() As String
        Get
            Return strG21ScientificName
        End Get
        Set(ByVal value As String)
            strG21ScientificName = value
            lblG21ScientificName.Text = value
            InitValues()
        End Set
    End Property

    Private Sub InitValues()

        strBTOCommonName = ""
        strBTOScientificName = ""
        cboCommonName.SelectedIndex = -1
        cboScientificName.SelectedIndex = -1
    End Sub

    Private strBTOCommonName As String
    Public ReadOnly Property BTOCommonName() As String
        Get
            Return strBTOCommonName
        End Get
    End Property

    Private strBTOScientificName As String
    Public ReadOnly Property BTOScientificName() As String
        Get
            Return strBTOScientificName
        End Get
    End Property

    Private Sub PopulateBTONames()

        Dim strResourcesDB As String = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "g21resources.db3")
        Dim conResources As SQLiteConnection = New SQLiteConnection("Data Source=" & strResourcesDB)

        Dim strSQL As String = "Select ScientificName, CommonName from BTOBirdNames;"
        Dim da As SQLiteDataAdapter = New SQLiteDataAdapter(strSQL, conResources)
        Dim dt As DataTable = New DataTable()
        da.Fill(dt)

        cboCommonName.DisplayMember = "CommonName"
        cboCommonName.ValueMember = "ScientificName"
        cboCommonName.DataSource = dt

        cboScientificName.DisplayMember = "ScientificName"
        cboScientificName.ValueMember = "CommonName"
        cboScientificName.DataSource = dt

        cboCommonName.SelectedIndex = -1
        cboScientificName.SelectedIndex = -1
    End Sub

    Private Sub frmBTOBirdNameMatch_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If cboCommonName.DisplayMember = "" Then
            PopulateBTONames()
        End If
    End Sub

    Private Sub butOK_Click(sender As System.Object, e As System.EventArgs) Handles butOK.Click

        strBTOCommonName = cboCommonName.Text
        strBTOScientificName = cboScientificName.Text
        Me.Close()
    End Sub

    Private Sub butCancel_Click(sender As System.Object, e As System.EventArgs) Handles butCancel.Click

        strBTOCommonName = ""
        strBTOScientificName = ""
        Me.Close()
    End Sub

    Private Sub cboCommonName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCommonName.SelectedIndexChanged

        butOK.Focus()
    End Sub

    Private Sub frmBTOBirdNameMatch_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        cboCommonName.Focus()
    End Sub
End Class