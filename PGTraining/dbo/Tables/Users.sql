CREATE TABLE [dbo].[Users] (
    [ID]                  INT           IDENTITY (1, 1) NOT NULL,
    [UserID]              VARCHAR (130) NOT NULL,
    [Password]            VARCHAR (255) NOT NULL,
    [Salt]                VARCHAR (255) NOT NULL,
    [StartExpirationDate] DATE          NOT NULL,
    [EndExpirationDate]   DATE          NOT NULL,
    [CreateDate]          DATETIME      NOT NULL,
    [ModifiedDate]        DATETIME      NULL,
    [AccessLevel]         INT           NOT NULL,
    CONSTRAINT [users_PKC] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_Users] UNIQUE NONCLUSTERED ([UserID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'作成日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'有効期限', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'EndExpirationDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID:サロゲートキー
自動インクリメント', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'ModifiedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'パスワード:1文字以上、253文字以下の半角英数字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Password';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ソルト:疑似乱数', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'Salt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ユーザーID:1文字以上、128文字以下の半角英数字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users', @level2type = N'COLUMN', @level2name = N'UserID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ユーザーテーブル:', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Users';

