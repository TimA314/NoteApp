namespace ToDo.Views;

public partial class AllNotes : ContentPage
{
	public AllNotes()
	{
		InitializeComponent();
		BindingContext = new Models.AllNotes();
	}

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
	{
		//Redirects to NotePage view
		await Shell.Current.GoToAsync(nameof(NotePage));
	}

	private async void notesCollection_Changed(object sender, SelectionChangedEventArgs e)
	{
		if (e.CurrentSelection.Count != 0)
		{
			var note = (Models.Note)e.CurrentSelection[0];

			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");

			notesCollection.SelectedItem = null;
		}
	}
}