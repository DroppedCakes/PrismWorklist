CREATE TABLE [dbo].[ExaminationOrders] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [OrderNumber]         VARCHAR (50)   NOT NULL,
    [ExaminationDate]     DATE           NOT NULL,
    [ProcessingDivision]  CHAR (1)       NOT NULL,
    [InfoID]              INT            NOT NULL,
    [ExaminationTypeCode] VARCHAR (10)   NOT NULL,
    [ExaminationTypeName] NVARCHAR (66)  NOT NULL,
    [Comment]             NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [examination_orders_PKC] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_examination_orders_examination_orders] FOREIGN KEY ([InfoID]) REFERENCES [dbo].[PatientInfomation] ([ID]),
    CONSTRAINT [AK_ExaminationOrders_Column] UNIQUE NONCLUSTERED ([OrderNumber] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'コメント', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'Comment';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'検査日付', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'ExaminationDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'検査種別コード', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'ExaminationTypeCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'検査種別名称', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'ExaminationTypeName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID:サロゲートキー
自動インクリメント', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'患者ID', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'InfoID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'オーダー番号:８文字の半角数字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'OrderNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'処理区分:1文字の半角数字(1,2,3のいずれか）', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders', @level2type = N'COLUMN', @level2name = N'ProcessingDivision';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'検査オーダー:', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ExaminationOrders';

