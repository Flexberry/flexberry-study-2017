





CREATE TABLE [Семестр] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Номер] INT  NOT NULL,

	 [Начало] DATETIME  NOT NULL,

	 [Конец] DATETIME  NOT NULL,

	 [Актуальность] BIT  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [ВыборПриоритета] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Приоритет] INT  NOT NULL,

	 [Актуальность] BIT  NULL,

	 [МодульВыбран] BIT  NULL,

	 [Модуль_m0] UNIQUEIDENTIFIER  NOT NULL,

	 [Студент] UNIQUEIDENTIFIER  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [Студент] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Фамилия] VARCHAR(255)  NOT NULL,

	 [Имя] VARCHAR(255)  NOT NULL,

	 [Отчество] VARCHAR(255)  NOT NULL,

	 [ДатаРождения] DATETIME  NOT NULL,

	 [Логин] VARCHAR(255)  NOT NULL,

	 [Пароль] VARCHAR(255)  NOT NULL,

	 [АдресПочты] VARCHAR(255)  NOT NULL,

	 [Обучается] BIT  NULL,

	 [КоличествоПрограмм] INT  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [Организация] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Название] VARCHAR(255)  NOT NULL,

	 [Описание] VARCHAR(255)  NOT NULL,

	 [Актуальность] BIT  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [Договор] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Номер] VARCHAR(255)  NOT NULL,

	 [Начало] DATETIME  NOT NULL,

	 [Конец] DATETIME  NOT NULL,

	 [Описание] VARCHAR(255)  NOT NULL,

	 [Актуальность] BIT  NULL,

	 [Организация] UNIQUEIDENTIFIER  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [Модуль] (

	 [primaryKey] UNIQUEIDENTIFIER  NOT NULL,

	 [Название] VARCHAR(255)  NOT NULL,

	 [Описание] VARCHAR(255)  NOT NULL,

	 [Актуальность] BIT  NULL,

	 [Организация_m0] UNIQUEIDENTIFIER  NOT NULL,

	 [Семестр_m0] UNIQUEIDENTIFIER  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMNETLOCKDATA] (

	 [LockKey] VARCHAR(300)  NOT NULL,

	 [UserName] VARCHAR(300)  NOT NULL,

	 [LockDate] DATETIME  NULL,

	 PRIMARY KEY ([LockKey]))


CREATE TABLE [STORMSETTINGS] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Module] varchar(1000)  NULL,

	 [Name] varchar(255)  NULL,

	 [Value] text  NULL,

	 [User] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMAdvLimit] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [User] varchar(255)  NULL,

	 [Published] bit  NULL,

	 [Module] varchar(255)  NULL,

	 [Name] varchar(255)  NULL,

	 [Value] text  NULL,

	 [HotKeyData] int  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMFILTERSETTING] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Name] varchar(255)  NOT NULL,

	 [DataObjectView] varchar(255)  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMWEBSEARCH] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Name] varchar(255)  NOT NULL,

	 [Order] INT  NOT NULL,

	 [PresentView] varchar(255)  NOT NULL,

	 [DetailedView] varchar(255)  NOT NULL,

	 [FilterSetting_m0] uniqueidentifier  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMFILTERDETAIL] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Caption] varchar(255)  NOT NULL,

	 [DataObjectView] varchar(255)  NOT NULL,

	 [ConnectMasterProp] varchar(255)  NOT NULL,

	 [OwnerConnectProp] varchar(255)  NULL,

	 [FilterSetting_m0] uniqueidentifier  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMFILTERLOOKUP] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [DataObjectType] varchar(255)  NOT NULL,

	 [Container] varchar(255)  NULL,

	 [ContainerTag] varchar(255)  NULL,

	 [FieldsToView] varchar(255)  NULL,

	 [FilterSetting_m0] uniqueidentifier  NOT NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [UserSetting] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [AppName] varchar(256)  NULL,

	 [UserName] varchar(512)  NULL,

	 [UserGuid] uniqueidentifier  NULL,

	 [ModuleName] varchar(1024)  NULL,

	 [ModuleGuid] uniqueidentifier  NULL,

	 [SettName] varchar(256)  NULL,

	 [SettGuid] uniqueidentifier  NULL,

	 [SettLastAccessTime] DATETIME  NULL,

	 [StrVal] varchar(256)  NULL,

	 [TxtVal] varchar(max)  NULL,

	 [IntVal] int  NULL,

	 [BoolVal] bit  NULL,

	 [GuidVal] uniqueidentifier  NULL,

	 [DecimalVal] decimal(20,10)  NULL,

	 [DateTimeVal] DATETIME  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [ApplicationLog] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Category] varchar(64)  NULL,

	 [EventId] INT  NULL,

	 [Priority] INT  NULL,

	 [Severity] varchar(32)  NULL,

	 [Title] varchar(256)  NULL,

	 [Timestamp] DATETIME  NULL,

	 [MachineName] varchar(32)  NULL,

	 [AppDomainName] varchar(512)  NULL,

	 [ProcessId] varchar(256)  NULL,

	 [ProcessName] varchar(512)  NULL,

	 [ThreadName] varchar(512)  NULL,

	 [Win32ThreadId] varchar(128)  NULL,

	 [Message] varchar(2500)  NULL,

	 [FormattedMessage] varchar(max)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMAG] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Name] varchar(80)  NOT NULL,

	 [Login] varchar(50)  NULL,

	 [Pwd] varchar(50)  NULL,

	 [IsUser] bit  NOT NULL,

	 [IsGroup] bit  NOT NULL,

	 [IsRole] bit  NOT NULL,

	 [ConnString] varchar(255)  NULL,

	 [Enabled] bit  NULL,

	 [Email] varchar(80)  NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMLG] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Group_m0] uniqueidentifier  NOT NULL,

	 [User_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMI] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [User_m0] uniqueidentifier  NOT NULL,

	 [Agent_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [Session] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [UserKey] uniqueidentifier  NULL,

	 [StartedAt] datetime  NULL,

	 [LastAccess] datetime  NULL,

	 [Closed] bit  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMS] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Name] varchar(100)  NOT NULL,

	 [Type] varchar(100)  NULL,

	 [IsAttribute] bit  NOT NULL,

	 [IsOperation] bit  NOT NULL,

	 [IsView] bit  NOT NULL,

	 [IsClass] bit  NOT NULL,

	 [SharedOper] bit  NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMP] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Subject_m0] uniqueidentifier  NOT NULL,

	 [Agent_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMF] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [FilterText] varchar(MAX)  NULL,

	 [Name] varchar(255)  NULL,

	 [FilterTypeNView] varchar(255)  NULL,

	 [Subject_m0] uniqueidentifier  NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMAC] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [TypeAccess] varchar(7)  NULL,

	 [Filter_m0] uniqueidentifier  NULL,

	 [Permition_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMLO] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Class_m0] uniqueidentifier  NOT NULL,

	 [Operation_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMLA] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [View_m0] uniqueidentifier  NOT NULL,

	 [Attribute_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMLV] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [Class_m0] uniqueidentifier  NOT NULL,

	 [View_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))


CREATE TABLE [STORMLR] (

	 [primaryKey] uniqueidentifier  NOT NULL,

	 [StartDate] datetime  NULL,

	 [EndDate] datetime  NULL,

	 [Agent_m0] uniqueidentifier  NOT NULL,

	 [Role_m0] uniqueidentifier  NOT NULL,

	 [CreateTime] datetime  NULL,

	 [Creator] varchar(255)  NULL,

	 [EditTime] datetime  NULL,

	 [Editor] varchar(255)  NULL,

	 PRIMARY KEY ([primaryKey]))




 ALTER TABLE [ВыборПриоритета] ADD CONSTRAINT [ВыборПриоритета_FМодуль_0] FOREIGN KEY ([Модуль_m0]) REFERENCES [Модуль]
CREATE INDEX ВыборПриоритета_IМодуль_m0 on [ВыборПриоритета] ([Модуль_m0])

 ALTER TABLE [ВыборПриоритета] ADD CONSTRAINT [ВыборПриоритета_FСтудент_0] FOREIGN KEY ([Студент]) REFERENCES [Студент]
CREATE INDEX ВыборПриоритета_IСтудент on [ВыборПриоритета] ([Студент])

 ALTER TABLE [Договор] ADD CONSTRAINT [Договор_FОрганизация_0] FOREIGN KEY ([Организация]) REFERENCES [Организация]
CREATE INDEX Договор_IОрганизация on [Договор] ([Организация])

 ALTER TABLE [Модуль] ADD CONSTRAINT [Модуль_FОрганизация_0] FOREIGN KEY ([Организация_m0]) REFERENCES [Организация]
CREATE INDEX Модуль_IОрганизация_m0 on [Модуль] ([Организация_m0])

 ALTER TABLE [Модуль] ADD CONSTRAINT [Модуль_FСеместр_0] FOREIGN KEY ([Семестр_m0]) REFERENCES [Семестр]
CREATE INDEX Модуль_IСеместр_m0 on [Модуль] ([Семестр_m0])

 ALTER TABLE [STORMWEBSEARCH] ADD CONSTRAINT [STORMWEBSEARCH_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0]) REFERENCES [STORMFILTERSETTING]

 ALTER TABLE [STORMFILTERDETAIL] ADD CONSTRAINT [STORMFILTERDETAIL_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0]) REFERENCES [STORMFILTERSETTING]

 ALTER TABLE [STORMFILTERLOOKUP] ADD CONSTRAINT [STORMFILTERLOOKUP_FSTORMFILTERSETTING_0] FOREIGN KEY ([FilterSetting_m0]) REFERENCES [STORMFILTERSETTING]

 ALTER TABLE [STORMLG] ADD CONSTRAINT [STORMLG_FSTORMAG_0] FOREIGN KEY ([Group_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMLG] ADD CONSTRAINT [STORMLG_FSTORMAG_1] FOREIGN KEY ([User_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMI] ADD CONSTRAINT [STORMI_FSTORMAG_0] FOREIGN KEY ([User_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMI] ADD CONSTRAINT [STORMI_FSTORMAG_1] FOREIGN KEY ([Agent_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMP] ADD CONSTRAINT [STORMP_FSTORMS_0] FOREIGN KEY ([Subject_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMP] ADD CONSTRAINT [STORMP_FSTORMAG_0] FOREIGN KEY ([Agent_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMF] ADD CONSTRAINT [STORMF_FSTORMS_0] FOREIGN KEY ([Subject_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMAC] ADD CONSTRAINT [STORMAC_FSTORMF_0] FOREIGN KEY ([Filter_m0]) REFERENCES [STORMF]

 ALTER TABLE [STORMAC] ADD CONSTRAINT [STORMAC_FSTORMP_0] FOREIGN KEY ([Permition_m0]) REFERENCES [STORMP]

 ALTER TABLE [STORMLO] ADD CONSTRAINT [STORMLO_FSTORMS_0] FOREIGN KEY ([Class_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLO] ADD CONSTRAINT [STORMLO_FSTORMS_1] FOREIGN KEY ([Operation_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLA] ADD CONSTRAINT [STORMLA_FSTORMS_0] FOREIGN KEY ([View_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLA] ADD CONSTRAINT [STORMLA_FSTORMS_1] FOREIGN KEY ([Attribute_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLV] ADD CONSTRAINT [STORMLV_FSTORMS_0] FOREIGN KEY ([Class_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLV] ADD CONSTRAINT [STORMLV_FSTORMS_1] FOREIGN KEY ([View_m0]) REFERENCES [STORMS]

 ALTER TABLE [STORMLR] ADD CONSTRAINT [STORMLR_FSTORMAG_0] FOREIGN KEY ([Agent_m0]) REFERENCES [STORMAG]

 ALTER TABLE [STORMLR] ADD CONSTRAINT [STORMLR_FSTORMAG_1] FOREIGN KEY ([Role_m0]) REFERENCES [STORMAG]
