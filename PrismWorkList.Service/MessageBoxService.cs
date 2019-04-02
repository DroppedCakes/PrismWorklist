using Prism.Interactivity.InteractionRequest;
using System.Windows;

namespace PrismWorkList.Service
{
    public class MessageBoxService : IMessageBoxService
    {
        public InteractionRequest<INotification> MessageBoxRequest { get; }

        public MessageBoxResult ShoowConfirmMessage(string message)
            => this.ShowConfirmMessage(message, "確認");

        public MessageBoxResult ShowConfirmMessage(string message, string title)
        {
            var confirm = new Confirmation()
            {
                Content = message,
                Title = title
            };

            var messageResult = MessageBoxResult.Cancel;
            this.MessageBoxRequest.Raise(confirm, r =>
             {
                 messageResult = (r as IConfirmation).Confirmed ? MessageBoxResult.OK : MessageBoxResult.Cancel;
             });

            return messageResult;
        }

        public MessageBoxResult ShowConfirmMessage(string message)
               => this.ShowConfirmMessage(message, "確認");

        /// <summary>情報メッセージボックスを表示します。</summary>
        /// <param name="message">メッセージボックスに表示する内容を表す文字列。</param>
        /// <param name="title">メッセージボックスのタイトルを表す文字列。</param>
        public void ShowInformationMessage(string message, string title)
        {
            var notify = new Notification()
            {
                Content = message,
                Title = title
            };

            this.MessageBoxRequest.Raise(notify);
        }

        public void ShowInformationMessage(string message)
        {
            this.ShowInformationMessage(message, "情報");
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MessageBoxService()
        {
            this.MessageBoxRequest = new InteractionRequest<INotification>();
        }
    }
}