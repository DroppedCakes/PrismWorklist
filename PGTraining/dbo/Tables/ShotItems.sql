CREATE TABLE [dbo].[ShotItems] (
    [ID]           INT           IDENTITY (1, 1) NOT NULL,
    [OrderID]      INT           NOT NULL,
    [ShotItemCode] VARCHAR (10)  NOT NULL,
    [ShotItemName] NVARCHAR (66) NOT NULL,
    CONSTRAINT [shot_items_PKC] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_shot_items_examination_orders] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[ExaminationOrders] ([ID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID:サロゲートキー
自動インクリメント', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShotItems', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'オーダーID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShotItems', @level2type = N'COLUMN', @level2name = N'OrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'撮影項目コード:1文字以上、8文字以下の半角英数字', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShotItems', @level2type = N'COLUMN', @level2name = N'ShotItemCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'撮影項目名称:1文字以上、32文字以下の任意の文字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShotItems', @level2type = N'COLUMN', @level2name = N'ShotItemName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'撮影項目:', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShotItems';

