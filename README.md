# Conceitos Abordados :books:

<!--Banner session-->
![csharp](./assets/csharp.svg "C#")

<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />


A implementação de mocks é uma prática comum no desenvolvimento de testes unitários, onde objetos simulados são utilizados para substituir dependências reais e controlar o comportamento esperado durante os testes. Vou descrever o processo geral de implementação de mocks e em seguida fazer uma comparação entre as ferramentas NSubstitute e Mockito.

Implementação de Mocks:

Escolha uma ferramenta de mocking: Existem várias bibliotecas disponíveis para implementação de mocks em diferentes linguagens de programação, como NSubstitute, Mockito, Moq, entre outras. Você precisa escolher uma biblioteca que seja compatível com a linguagem de programação que você está utilizando.

Configure a dependência a ser substituída: Identifique a dependência que será substituída pelo mock. Isso pode ser uma classe, uma interface ou um objeto que você deseja simular durante o teste.

Crie o mock: Utilize a biblioteca de mocking para criar o mock da dependência. Isso geralmente envolve criar um objeto simulado que implementa a mesma interface ou classe da dependência real.

Defina o comportamento do mock: Configure o comportamento esperado do mock. Por exemplo, você pode definir quais métodos devem ser chamados, quais valores devem ser retornados ou quais exceções devem ser lançadas em determinadas situações.

Utilize o mock nos testes: Substitua a dependência real pelo mock nos testes. Assim, você terá controle total sobre o comportamento do objeto simulado e poderá verificar se as interações esperadas ocorreram corretamente durante o teste.

NSubstitute vs. Mockito:

Aqui estão algumas características, prós e contras das bibliotecas NSubstitute e Mockito:

NSubstitute:

Características:
•	Sintaxe fluente e fácil de usar.
•	Suporta substituição de interfaces e classes concretas.
•	Permite configurar o comportamento dos mocks de forma simples e clara.
•	Fornece recursos adicionais, como verificações de argumentos e substitutos parciais.
Prós:
•	Sintaxe clara e legível, o que torna os testes mais expressivos.
•	Fácil integração com a maioria das estruturas de teste.
•	Suporta a criação de mocks tanto para interfaces quanto para classes concretas.
•	Boa documentação e comunidade ativa.
Contras:
•	Algumas funcionalidades avançadas podem não estar disponíveis.
•	Pode ser necessário escrever mais código em casos complexos de configuração de mocks.

Mockito:

Características:
•	Biblioteca popular para mock em Java.
•	Suporta substituição de interfaces e classes concretas.
•	Possui uma sintaxe clara e concisa.
Prós:
•	Sintaxe simples e intuitiva.
•	Amplamente adotado e com uma comunidade ativa.
•	Oferece recursos avançados, como verificação de chamadas, captura de argumentos e comportamento condicional.
Contras:
•	Foco principal na linguagem Java, embora haja suporte para outras linguagens por meio de portes ou bibliotecas relacionadas.
•	Pode haver uma curva de aprendizado inicial para dominar todos os recursos.

Ambas as ferramentas, NSubstitute e Mockito, são amplamente utilizadas e oferecem recursos eficientes para a implementação de mocks. A escolha entre elas dependerá principalmente da linguagem de programação que você está utilizando e das preferências pessoais. É recomendado experimentar as bibliotecas e verificar qual delas melhor atende às suas necessidades em termos de facilidade de uso, funcionalidades disponíveis e integração com seu ambiente de teste.

</details>



<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />


A implementação de mocks é uma prática comum no desenvolvimento de testes unitários, onde objetos simulados são utilizados para substituir dependências reais e controlar o comportamento esperado durante os testes. Vou descrever o processo geral de implementação de mocks e em seguida fazer uma comparação entre as ferramentas NSubstitute e Mockito.

Implementação de Mocks:

Escolha uma ferramenta de mocking: Existem várias bibliotecas disponíveis para implementação de mocks em diferentes linguagens de programação, como NSubstitute, Mockito, Moq, entre outras. Você precisa escolher uma biblioteca que seja compatível com a linguagem de programação que você está utilizando.

Configure a dependência a ser substituída: Identifique a dependência que será substituída pelo mock. Isso pode ser uma classe, uma interface ou um objeto que você deseja simular durante o teste.

Crie o mock: Utilize a biblioteca de mocking para criar o mock da dependência. Isso geralmente envolve criar um objeto simulado que implementa a mesma interface ou classe da dependência real.

Defina o comportamento do mock: Configure o comportamento esperado do mock. Por exemplo, você pode definir quais métodos devem ser chamados, quais valores devem ser retornados ou quais exceções devem ser lançadas em determinadas situações.

Utilize o mock nos testes: Substitua a dependência real pelo mock nos testes. Assim, você terá controle total sobre o comportamento do objeto simulado e poderá verificar se as interações esperadas ocorreram corretamente durante o teste.

NSubstitute vs. Mockito:

Aqui estão algumas características, prós e contras das bibliotecas NSubstitute e Mockito:

NSubstitute:

Características:
•	Sintaxe fluente e fácil de usar.
•	Suporta substituição de interfaces e classes concretas.
•	Permite configurar o comportamento dos mocks de forma simples e clara.
•	Fornece recursos adicionais, como verificações de argumentos e substitutos parciais.
Prós:
•	Sintaxe clara e legível, o que torna os testes mais expressivos.
•	Fácil integração com a maioria das estruturas de teste.
•	Suporta a criação de mocks tanto para interfaces quanto para classes concretas.
•	Boa documentação e comunidade ativa.
Contras:
•	Algumas funcionalidades avançadas podem não estar disponíveis.
•	Pode ser necessário escrever mais código em casos complexos de configuração de mocks.

Mockito:

Características:
•	Biblioteca popular para mock em Java.
•	Suporta substituição de interfaces e classes concretas.
•	Possui uma sintaxe clara e concisa.
Prós:
•	Sintaxe simples e intuitiva.
•	Amplamente adotado e com uma comunidade ativa.
•	Oferece recursos avançados, como verificação de chamadas, captura de argumentos e comportamento condicional.
Contras:
•	Foco principal na linguagem Java, embora haja suporte para outras linguagens por meio de portes ou bibliotecas relacionadas.
•	Pode haver uma curva de aprendizado inicial para dominar todos os recursos.

Ambas as ferramentas, NSubstitute e Mockito, são amplamente utilizadas e oferecem recursos eficientes para a implementação de mocks. A escolha entre elas dependerá principalmente da linguagem de programação que você está utilizando e das preferências pessoais. É recomendado experimentar as bibliotecas e verificar qual delas melhor atende às suas necessidades em termos de facilidade de uso, funcionalidades disponíveis e integração com seu ambiente de teste.

</details>



<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />


```bash
const entrada = gets();
```

</details>


<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />


```bash
const entrada = gets();
```

</details>


## 📜 License

O projeto lançado em 2023 sobre a licença [MIT](./LICENSE) ❤️ 

Made with ♥ by Shyoutarou

Gostou? Deixe uma estrelinha para ajudar o projeto ⭐