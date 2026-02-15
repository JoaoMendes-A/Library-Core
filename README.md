# Sistema de Gerenciamento de Biblioteca

Aplicação de console desenvolvida em **C#** com o objetivo de realizar o gerenciamento de uma biblioteca, permitindo o controle de livros, usuários e empréstimos.

Este projeto foi criado para praticar e consolidar conceitos de **Programação Orientada a Objetos (POO)**, organização em camadas e implementação de regras de negócio aplicadas a um cenário real.

---

## Visão Geral

O sistema permite o cadastro e gerenciamento completo de uma biblioteca, controlando a disponibilidade dos livros e os empréstimos realizados por usuários.

---

## Funcionalidades

**Livros**

* Cadastro de novos livros
* Listagem completa
* Exibição de disponibilidade em estoque

**Usuários**

* Cadastro de usuários
* Listagem de usuários registrados

**Empréstimos**

* Realização de empréstimos
* Registro de data do empréstimo
* Controle de empréstimos ativos

**Devoluções**

* Registro de devolução
* Atualização automática do estoque

---

## Regras de Negócio

* O empréstimo só é permitido se houver quantidade disponível do livro
* Cada usuário pode emprestar no máximo 3 livros simultaneamente
* Um mesmo livro não pode ser emprestado duas vezes para o mesmo usuário
* A devolução atualiza automaticamente a quantidade disponível

---

## Tecnologias Utilizadas

| Tecnologia          | Descrição                      |
| ------------------- | ------------------------------ |
| C#                  | Linguagem principal do projeto |
| .NET                | Plataforma de execução         |
| Console Application | Interface da aplicação         |







