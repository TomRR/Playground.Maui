function SendMessageToCSharp() {
    var message = document.getElementById('input__message').value;
    HybridWebView.SendRawMessageToDotNet(message);
}