# Sistema de Patrimônio — API

API REST para **gestão de patrimônios** de uma instituição: cadastro de itens, localização (cidade, bairro, endereço, área e ambiente), status, **solicitações de transferência** e **histórico de alterações** de cada patrimônio, com controle de acesso por perfil.

> O front-end está em [GestaoPatrimonios](https://github.com/LeonardoFuents/GestaoPatrimonios).

## Funcionalidades

- **Login com JWT** e **troca obrigatória da primeira senha**
- **Perfis de acesso**: ações administrativas restritas ao perfil `Coordenador`
- Cadastro de **usuários**, **cargos** e **tipos de usuário**, com ativação/desativação
- Estrutura de localização: **Cidade → Bairro → Endereço → Área → Localização**
- **Status do patrimônio** e **tipos de alteração**
- **Solicitações de transferência** entre ambientes, com status próprio
- **Histórico (log)** de alterações por patrimônio
- Senhas criptografadas e validações de regra de negócio

## Tecnologias

- **.NET 8** / ASP.NET Core Web API
- **Entity Framework Core** + **SQL Server**
- Autenticação **JWT** com roles
- **DotNetEnv** (variáveis em `.env`)
- **Swagger** (Swashbuckle)

## Estrutura

```
Controllers/        # um controller por entidade + Autenticacao
Applications/
  Services/         # regras de negócio
  Autenticacao/     # JWT e criptografia de senha
  Regras/           # validações
Domains/            # Patrimonio, Localizacao, Area, Endereco, Usuario, LogPatrimonio, ...
DTOs/  Interfaces/  Repositories/  Contexts/
```

## Endpoints (resumo)

| Recurso | Rotas |
|---|---|
| Autenticação | `POST /api/Autenticacao/login` · `PATCH /api/Autenticacao/trocar-senha` |
| Usuários | `GET/POST /api/Usuario` · `GET/PUT /api/Usuario/{id}` · `PATCH /api/Usuario/{id}/status` |
| Localização | `/api/Cidade` · `/api/Bairro` · `/api/Endereco` · `/api/Area` · `/api/Localizacao` |
| Cadastros auxiliares | `/api/Cargo` · `/api/TipoUsuario` · `/api/StatusPatrimonio` · `/api/StatusTransferencia` · `/api/TipoAlteracao` |
| Transferências | `GET /api/SolicitacaoTransferencia` · `GET /api/SolicitacaoTransferencia/{id}` |
| Histórico | `GET /api/LogPatrimonio` · `GET /api/LogPatrimonio/patrimonio/{id}` |

## Como rodar

Pré-requisitos: .NET 8 SDK e SQL Server.

1. Copie `.env.example` para `.env` e preencha a connection string e a chave JWT.
2. Execute:

```bash
dotnet restore
dotnet run
```

3. Documentação em `https://localhost:<porta>/swagger`.

## Autor

**Leonardo Fuentes** — [GitHub](https://github.com/LeonardoFuents)
