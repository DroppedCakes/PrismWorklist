CREATE TABLE [dbo].[PatientInfomation] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [PatientID] VARCHAR (50)   NOT NULL,
    [KanjiName] NVARCHAR (130) NOT NULL,
    [KanaName]  NVARCHAR (130) NOT NULL,
    [BirthDate] DATE           NOT NULL,
    [Gender]    CHAR (1)       NOT NULL,
    CONSTRAINT [patient_infomation_PKC] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [AK_PatientInfomation_Column] UNIQUE NONCLUSTERED ([PatientID] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'生年月日', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'BirthDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'性別:F,M,Oのみが入る。
それぞれ女性、男性、不明を表す', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'Gender';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ID:サロゲートキー
自動インクリメント', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'ID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'カナ氏名:1文字以上、64文字以下の半角', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'KanaName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'氏名:1文字以上、64文字以下の任意文字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'KanjiName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'患者ID:10文字の半角英数字列', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation', @level2type = N'COLUMN', @level2name = N'PatientID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'患者属性情報', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PatientInfomation';

