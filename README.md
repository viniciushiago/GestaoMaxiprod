📊 GestaoMaxiprod
API de Gestão Financeira — .NET 9
📌 Visão Geral

O GestaoMaxiprod é uma API de gestão financeira desenvolvida em .NET 9, com foco em arquitetura limpa, organização de código e regras de negócio bem definidas, simulando um cenário real de aplicação corporativa.

O projeto foi pensado tanto como base sólida de backend quanto como material de estudo e avaliação técnica.

🏗️ Arquitetura Adotada

Este projeto utiliza uma combinação de padrões amplamente utilizados no mercado:

🧠 DDD (Domain-Driven Design)

🔌 Arquitetura Hexagonal (Ports & Adapters)

🔄 CQRS (Command Query Responsibility Segregation)

📬 Mediator Pattern (MediatR)

🎯 Objetivos dessas escolhas

Baixo acoplamento entre camadas

Alta coesão

Facilidade de manutenção

Clareza na separação de responsabilidades

Evolução segura do código

📁 Estrutura dos Projetos
GestaoMaxiprod
│
├── Domain
├── Application
├── Infrastructure
└── API

🧠 Domain (Camada de Domínio)

Responsável por conter o núcleo da aplicação.

Contém:

Entidades (Person, Category, Transaction)

Enums (TransactionType, CategoryPurpose)

Regras de negócio

Validações e comportamentos das entidades

📌 Regra de ouro:
O domínio não depende de nenhuma outra camada.

⚙️ Application (Casos de Uso)

Camada responsável por orquestrar os fluxos da aplicação.

Principais responsabilidades:

Commands (operações de escrita)

Queries (operações de leitura)

Handlers (execução dos casos de uso)

DTOs / Responses

Interfaces de repositórios (Ports)

CQRS aplicado:

✏️ Commands → criam, alteram ou removem dados

🔍 Queries → apenas leitura, sem efeitos colaterais

📌 Nenhuma regra de persistência ou detalhe técnico fica aqui.

🗄️ Infrastructure (Infraestrutura)

Camada responsável pelos detalhes técnicos.

Inclui:

Entity Framework Core

DbContext

Configurações de entidades (IEntityTypeConfiguration)

Implementações dos repositórios

Configuração do PostgreSQL

📌 Implementa as interfaces definidas na camada Application.

🌐 API (Web)

Camada de entrada da aplicação.

Responsabilidades:

Controllers

Configuração de Dependency Injection

Pipeline HTTP

Integração com MediatR

📌 Controllers não possuem regras de negócio
Apenas recebem a requisição e delegam para a Application.

🔄 CQRS + MediatR

Cada operação do sistema possui:

Um Command ou Query

Um Handler responsável pela execução

Benefícios:

Desacoplamento entre API e lógica de negócio

Código mais testável

Fluxos claros e previsíveis

🧩 Repository Pattern

Utilizado para abstrair o acesso ao banco de dados.

Características:

Repositórios retornam entidades

Não contêm regras de negócio

Encapsulam operações de persistência

// O repositório apenas acessa dados,
// sem aplicar validações ou regras

🧠 Regras de Negócio
👤 Pessoa

Identificador único

Nome e idade

Ao ser removida:

❌ Todas as transações associadas são excluídas

Implementado com DeleteBehavior.Cascade

🗂️ Categoria

Finalidade:

Receita

Despesa

Ambas

❌ Não pode ser removida se houver transações vinculadas

Implementado com DeleteBehavior.Restrict

💰 Transação

Regras aplicadas no domínio:

Valor deve ser positivo

Menores de idade (< 18 anos) só podem registrar despesas

Categoria deve ser compatível com o tipo da transação

Ex.: despesa ❌ categoria de receita

📌 Centralizar essas regras no domínio garante consistência do sistema.

📊 Relatórios

Foi criado um módulo específico para consultas agregadas:

Totais de receitas por pessoa

Totais de despesas por pessoa

Saldo individual

Totais gerais consolidados

📌 Esses relatórios:

Não pertencem a uma entidade específica

Representam consultas de negócio

Ficam organizados em Reports

🗃️ Entity Framework Core

Utilizado como ORM

Mapeamento via IEntityTypeConfiguration

Separação clara entre entidade e persistência

Uso de AsNoTracking() em consultas de leitura

Enums

Persistidos como int

Melhor performance

Simplicidade no banco

Facilidade de versionamento

🧪 Decisões Técnicas Importantes

🧾 Records para DTOs e Responses
→ Imutabilidade e clareza

🧱 Classes para entidades
→ Encapsulam comportamento

🎯 Handlers enxutos
→ Regras no domínio

🌐 Controllers simples
→ Entrada e saída apenas

✅ Conclusão

Este projeto foi construído com foco em:

Código limpo

Arquitetura sólida

Padrões amplamente utilizados no mercado

Manutenção e evolução contínua

🚀 Uma base realista para aplicações corporativas
🎓 Um excelente material para estudo e entrevistas técnicas
