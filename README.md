# Forum

Este é um projeto básico de fórum desenvolvido em C#, utilizando alguns conceitos de Domain-Driven Design (DDD) e Arquitetura Monolítica Modular. Adicionalmente também estou estudando conceitos de Clean Code, pois o objetivo aqui não é me prender a alguma arquitetura ou estrutura, mas sim utilizar aquilo que melhor atende as minhas necessidades.

## Estrutura do Projeto

O projeto está organizado nas seguintes camadas:

- **Domain**: Contém as entidades, objetos de valor, interfaces de repositório e lógica de negócio.
- **Infrastructure**: Implementa os repositórios e contexto de dados, conectando a camada de domínio ao banco de dados. Além disso, implementa serviços auxiliares como PasswordHasher, atualmente.
- **Application**: (Em desenvolvimento) Gerencia os casos de uso e a lógica de aplicação, orquestrando as operações entre as camadas de domínio e infraestrutura.
- **Web**: (Em desenvolvimento) Fornece a interface do usuário e expõe os endpoints da API para interação com o sistema.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Plataforma**: .NET Core

## Próximos Passos

- Desenvolver a camada **Application** para gerenciar os casos de uso.
- Implementar a camada **Web** para fornecer a interface do usuário e os endpoints da API.
- Escrever testes unitários para as camadas concluídas.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests com melhorias e correções.

## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
