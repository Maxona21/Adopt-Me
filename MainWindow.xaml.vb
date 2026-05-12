Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Collections.Generic

Namespace AdoptMe

    Partial Public Class MainWindow
        Inherits Window

        Private petDescriptions As New Dictionary(Of String, String)()
        Private reservations As New List(Of String)()

        Public Sub New()
            InitializeComponent()

            petDescriptions("Kapcio") = "Kapcio - friendly, 2 years old, loves cuddles."
            petDescriptions("Lexio") = "Lexio - playful, 1 year old, good with kids."
            petDescriptions("Macio") = "Macio - calm, 4 years old, house-trained."
            petDescriptions("Arturcio") = "Arturcio - energetic, 3 years old, needs space to play."
            petDescriptions("Romcio") = "Romcio - curious, 2 years old, loves toys."
            petDescriptions("Filipcio") = "Filipcio - gentle, 5 years old, enjoys naps."
            petDescriptions("Michcio") = "Michcio - shy but sweet, 2 years old, warms up quickly."
            petDescriptions("Sebcio") = "Sebcio - confident, 3 years old, great companion."
            petDescriptions("Czario") = "Czario - bardzo zabiegły gość, 3 lata, uwielbia towarzystwo innych zwierząt."
        End Sub

        Private Sub PetImage_Click(sender As Object, e As MouseButtonEventArgs)
            Dim img = TryCast(sender, Image)
            If img Is Nothing Then Return

            Dim key As String = If(img.Tag IsNot Nothing, img.Tag.ToString(), String.Empty)
            If String.IsNullOrEmpty(key) Then Return

            txtPetName.Text = key
            Dim desc As String = If(petDescriptions.ContainsKey(key), petDescriptions(key), "Information not available.")
            txtPetDescription.Text = desc
            previewImage.Source = img.Source

            InfoCard.Visibility = Visibility.Visible
        End Sub

        Private Sub BtnConfirm_Click(sender As Object, e As RoutedEventArgs)
            Dim name = txtPetName.Text
            If String.IsNullOrEmpty(name) Then
                MessageBox.Show("No pet selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error)
                Return
            End If

            reservations.Add(name)
            MessageBox.Show(String.Format("{0} reserved. Thank you!", name), "Reservation", MessageBoxButton.OK, MessageBoxImage.Information)
            InfoCard.Visibility = Visibility.Collapsed
        End Sub

        Private Sub BtnClose_Click(sender As Object, e As RoutedEventArgs)
            InfoCard.Visibility = Visibility.Collapsed
        End Sub
    End Class

End Namespace
