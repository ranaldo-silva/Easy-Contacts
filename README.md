# Checkpoint 2 ASP.NET Core MVC - Easy Contacts

Projeto da disciplina de Análise e Desenvolvimento de Sistemas (FIAP) para a criação de um CRUD Web de uma agenda de contatos (Easy Contacts).

## Integrantes do Grupo

* **Nome Completo:** Ranaldo José da Silva - **RM:** 559210
* **Nome Completo:** Marcos Vinicius Alves Marques - **RM:** 560475
* **Nome Completo:** Jonas Kimio Isiki - **RM:** 560560
* **Nome Completo:** Daniel Kendi Saijo Araki - **RM:** 553043
* **Nome Completo:** Lucas da Ressurreição Barbosa - **RM:** 560179
* **Nome Completo:** Fabricio José da Silva - **RM:** 560694

---

## 1. Descrição do Projeto

O projeto "Easy Contacts" é uma aplicação Web desenvolvida em ASP.NET Core MVC com o objetivo de gerenciar uma agenda de contatos. A aplicação não utiliza um banco de dados neste momento; os dados são persistidos em memória (através de um repositório estático) enquanto a aplicação está em execução.

## 2. Diagrama de Classes

(Conforme solicitado, um diagrama simples das classes principais do projeto)


---

## 3. Telas e Funcionalidades 

Conforme solicitado, seguem as telas da aplicação com explicações de implementação e funcionamento.

### Tela 1: Home Page (Index da Home)

* **Descrição:** Tela inicial de boas-vindas da aplicação.
* **Implementação:** Esta é a `Views/Home/Index.cshtml`. Foi personalizada para apresentar o projeto e direcionar o usuário para a funcionalidade principal.
<img width="1265" height="690" alt="image" src="https://github.com/user-attachments/assets/47258495-c7c0-4942-aaa1-997ea2864946" />


### Tela 2: Listagem de Contatos (Index dos Contatos)

* **Descrição:** Tela principal do CRUD. Lista todos os contatos existentes e permite iniciar as ações de Criar, Editar, Detalhar, Excluir e Pesquisar.
* **Implementação:** É a `Views/Contatos/Index.cshtml`. Ela recebe uma `IEnumerable<Contato>` do `ContatosController`. Inclui botões coloridos, tabela zebrada (`table-striped`) e um formulário GET para a funcionalidade de pesquisa por nome.
<img width="1129" height="205" alt="image" src="https://github.com/user-attachments/assets/912b5705-4166-4d59-80e8-8e0e45bfbafd" />

### Tela 3: Pesquisa por Nome

* **Descrição:** Funcionalidade na tela de listagem que filtra os contatos cujo nome contenha o texto digitado.
* **Implementação:** O formulário da `Index.cshtml` envia uma string `pesquisaNome` para a Action `Index` do `ContatosController`, que filtra a lista usando `Where()` antes de passá-la para a View.
<img width="1268" height="331" alt="image" src="https://github.com/user-attachments/assets/1b2352cf-c9c4-4dee-a06e-5218eccbcc08" />

### Tela 4: Criação de Contato (Create)

* **Descrição:** Formulário para adicionar um novo contato.
* **Implementação:** `Views/Contatos/Create.cshtml`. Utiliza Tag Helpers (`asp-for`, `asp-validation-for`). O campo "Tipo de Contato" é um `<select>` populado por um `Enum` (`TipoContato`) enviado pelo Controller via `ViewBag`.
<img width="553" height="627" alt="image" src="https://github.com/user-attachments/assets/f6810844-e520-4df2-9170-10b1c2fdea15" />

### Tela 5: Edição de Contato (Edit)

* **Descrição:** Formulário pré-preenchido para alterar um contato existente.
* **Implementação:** Similar à tela de Create (`Views/Contatos/Edit.cshtml`), mas utiliza um `<input type="hidden" asp-for="Id" />` para rastrear o contato que está sendo editado.
<img width="493" height="614" alt="image" src="https://github.com/user-attachments/assets/c8ff3bb6-a0f2-43e6-a780-6be19ccda5bd" />

### Tela 6: Confirmação de Remoção (Delete)

* **Descrição:** Tela de confirmação exigida antes de excluir um contato.
* **Implementação:** `Views/Contatos/Delete.cshtml`. Mostra os dados do contato e pede confirmação. Ao confirmar, envia um POST para a Action `DeleteConfirmed` no Controller.
<img width="680" height="495" alt="image" src="https://github.com/user-attachments/assets/48648a3f-2dd6-49a2-822a-039c0583d33d" />

---

## 4. Tecnologias e Pacotes NuGet

Conforme solicitado, estas são as tecnologias e pacotes utilizados no projeto:

* **Framework:** .NET (Versão utilizada, ex: .NET 6.0 ou 7.0)
* **Linguagem:** C#
* **IDE:** Visual Studio 2022 (conforme exigido)
* **Arquitetura:** ASP.NET Core MVC
* **Pacotes NuGet Padrão:**
    * `Microsoft.AspNetCore.Mvc`
    * `Microsoft.NET.Sdk.Web`
* **Padrões:**
    * **MVC (Model-View-Controller):** Separação das responsabilidades.
    * **Repository Pattern (Simplificado):** Uma classe estática (`ContatoRepository`) foi usada para simular o acesso aos dados em memória.
* **Front-end:**
    * HTML5
    * CSS3
    * Bootstrap 5 (para o layout responsivo e componentes visuais)
