namespace MauiUi.React.TodoApp;

public partial class TodoPage : ContentPage
{
    private readonly TodoDataStore _todoDataStore;
    
    public TodoPage()
    {
        InitializeComponent();
        
        _todoDataStore = new TodoDataStore();
        _todoDataStore.TaskDataChanged += OnTodoDataChanged;
        
#if DEBUG
        ReactTodoWebView.EnableWebDevTools = true;
#endif

        ReactTodoWebView.JSInvokeTarget = new TodoJSInvokeTarget(this, _todoDataStore);

        BindingContext = this;
    }
    public string TodoAppTitle => $"Todo items: {_todoDataStore.GetData().Count}";

    private void OnTodoDataChanged(object sender, EventArgs e)
    {
        OnPropertyChanged(nameof(TodoAppTitle));
    }

    private async void SendUpdatedTasksToJS(IList<TodoTask> tasks)
    {
        _ = await MainThread.InvokeOnMainThreadAsync(async () =>
            await ReactTodoWebView.InvokeJsMethodAsync("globalSetData", tasks));
    }

    private sealed class TodoJSInvokeTarget
    {
        private TodoPage _todoPage;
        private readonly TodoDataStore _todoDataStore;

        public TodoJSInvokeTarget(TodoPage todoPage, TodoDataStore todoDataStore)
        {
            _todoPage = todoPage;
            _todoDataStore = todoDataStore;
        }

        public void StartTaskLoading()
        {
            _todoPage.SendUpdatedTasksToJS(_todoDataStore.GetData());
        }

        public void AddTask(TodoTask newTask)
        {
            _todoDataStore.AddTask(newTask);
        }

        public void EditTask(string id, string newName)
        {
            _todoDataStore.EditTask(id, newName);
        }

        public void DeleteTask(string id)
        {
            _todoDataStore.DeleteTask(id);
        }

        public void ToggleCompletedTask(string id)
        {
            _todoDataStore.ToggleCompletedTask(id);
        }
    }
}