📊 GestaoMaxiprod – API de Gestão Financeira

Este projeto é uma API de gestão financeira desenvolvida em .NET 9, com foco em boas práticas de arquitetura, organização de código e regras de negócio claras, simulando um cenário real de aplicação corporativa.

🏗️ Arquitetura Geral

O projeto foi estruturado utilizando uma combinação de:

DDD (Domain-Driven Design)

Arquitetura Hexagonal (Ports & Adapters)

CQRS (Command Query Responsibility Segregation)

Mediator Pattern (MediatR)

O objetivo principal dessas escolhas é garantir:

Baixo acoplamento

Alta coesão

Facilidade de manutenção e evolução

Clareza na separação de responsabilidades

📁 Organização dos Projetos
🧠 Domain

Responsável por conter o coração da aplicação.

Inclui:

Entidades (Person, Category, Transaction)

Enums (TransactionType, CategoryPurpose)

Regras de negócio

Validações internas das entidades

📌 Regra importante:
O domínio não depende de nenhum outro projeto.

⚙️ Application

Contém os casos de uso da aplicação.

Utiliza CQRS, separando claramente:

Commands → operações que alteram estado (Create, Delete)

Queries → operações de leitura (Listagens, Relatórios)

Inclui:

Commands e CommandHandlers

Queries e QueryHandlers

DTOs / Responses

Interfaces de repositórios (ports)

📌 Aqui ficam as orquestrações, não regras de persistência nem detalhes de infraestrutura.

🗄️ Infrastructure

Responsável por detalhes técnicos.

Inclui:

Entity Framework Core

DbContext

Mapeamentos (IEntityTypeConfiguration)

Implementações de repositórios

Configuração do PostgreSQL

📌 Este projeto implementa as interfaces definidas na camada Application.

🌐 API (Web)

Camada de entrada da aplicação.

Inclui:

Controllers

Configuração de DI

Configuração do pipeline HTTP

📌 Controllers não contêm regras de negócio, apenas:

Recebem a requisição

Enviam comandos/queries via MediatR

Retornam a resposta

🔄 CQRS + MediatR

O padrão CQRS foi adotado para separar:

Leitura (Queries)

Escrita (Commands)

Cada operação possui:

Um objeto de Request (Command ou Query)

Um Handler responsável por executar o caso de uso

O MediatR é utilizado para:

Desacoplar Controllers da lógica da aplicação

Centralizar o fluxo de execução

Facilitar testes e manutenção

🧩 Repository Pattern

O padrão Repository foi utilizado para:

Abstrair o acesso ao banco de dados

Evitar dependência direta do EF Core na Application

Centralizar operações de persistência

📌 Importante:

Repositórios não contêm regras de negócio

Apenas operações de leitura e escrita

🧠 Regras de Negócio Implementadas
👤 Pessoa

Possui identificador único

Contém nome e idade

Ao ser removida, todas as transações associadas são excluídas

Implementado com DeleteBehavior.Cascade

🗂️ Categoria

Pode ser de Despesa, Receita ou Ambas

Não pode ser removida caso esteja sendo utilizada por transações

Implementado com DeleteBehavior.Restrict

💰 Transação

Regras aplicadas no domínio:

Valor deve ser positivo

Menores de idade (< 18 anos) só podem registrar despesas

Tipo da transação deve ser compatível com a finalidade da categoria

Ex.: transação de despesa não pode usar categoria de receita

📌 Todas essas regras ficam centralizadas no domínio, garantindo consistência.

📊 Relatórios

Foi criado um módulo específico para consultas agregadas, como:

Total de receitas por pessoa

Total de despesas por pessoa

Saldo individual

Totais gerais consolidados

📌 Esses relatórios:

Não pertencem a uma entidade específica

Representam consultas de negócio

Por isso ficam organizados em Reports

🗃️ Entity Framework Core

Utilizado como ORM

Mapeamentos feitos via IEntityTypeConfiguration

Separação clara entre entidade e persistência

Uso de AsNoTracking() em consultas de leitura para melhor performance

Enums são persistidos como int para:

Melhor performance

Simplicidade no banco

Facilidade de versionamento

🎯 Decisões Importantes

Records utilizados para DTOs/Responses
→ Imutabilidade e clareza de intenção

Classes utilizadas para entidades
→ Comportamento e regras encapsuladas

Handlers enxutos
→ Regras no domínio, não no application

Controllers simples
→ Apenas entrada e saída

✅ Conclusão

Este projeto foi construído com foco em:

Código limpo

Arquitetura consistente

Boas práticas amplamente utilizadas no mercado

Facilidade de evolução futura

Ele serve tanto como base real de projeto, quanto como material de estudo e avaliação técnica.
