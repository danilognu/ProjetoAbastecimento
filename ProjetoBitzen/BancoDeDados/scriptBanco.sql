
CREATE DATABASE BTZTransports;

CREATE TABLE [dbo].[Motorista](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[CPF] [varchar](14) NULL,
	[CNH] [varchar](15) NULL,
	[Categoria] [varchar](100) NULL,
	[DataNascimento] [datetime] NULL,
	[Status] [int] NULL,
	[DataCadastroAlteracao] [datetime] NULL,
 CONSTRAINT [PK_motorista] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO



CREATE TABLE [dbo].[Veiculo](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[TipoCombustivel] [varchar](100) NULL,
	[Fabricante] [varchar](100) NULL,
	[AnoFabricacao] [int] NULL,
	[CapacidadeTanque] [decimal](10,2) NULL,
	[Observacao] [varchar](300) NULL,
	[DataCadastroAlteracao] [datetime] NULL,
 CONSTRAINT [PK_Veiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Abastecimento](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[VeiculoId] [int] NOT NULL,
	[MotoristaId] [int] NULL,
	[TipoCombustivel] [varchar](100) NULL,
	[Data] [datetime] NULL,
	[QuantidadeAbastecida] [decimal](10,2) NULL,
	[DataCadastroAlteracao] [datetime] NULL,
 CONSTRAINT [PK_Abastecimento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Login] [varchar](100) NULL,
	[Senha] [varchar](300) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 80) ON [PRIMARY]
) ON [PRIMARY]
GO

