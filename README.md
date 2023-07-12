<h1 align="center">Conceitos Aboradados :books:</h1>
 
<!--Banner session-->
<img src="./assets/csharp.svg" alt="csharp" tittle="C#" width="70" height="70">
 
<!-- C Sharp -->
<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />
    <div align="left">

	Domain-Driven Design (DDD) é uma abordagem de design de software que se concentra na modelagem do domínio do problema em questão. O objetivo principal do DDD é desenvolver sistemas que reflitam de forma precisa e eficaz as regras e conceitos do negócio, tornando o código mais legível, compreensível e escalável.

	No DDD, o "domínio" refere-se à área de conhecimento específica que o software está tentando resolver. Pode ser qualquer coisa, desde uma aplicação bancária até um sistema de gerenciamento de pedidos online. O DDD coloca o domínio no centro do design do software, buscando compreender profundamente os requisitos, processos e regras do domínio.

	Aqui estão alguns conceitos-chave do DDD:

	1.	Modelagem do domínio: No DDD, o domínio é modelado através de entidades, agregados, serviços, eventos e valores de objetos. A ideia é criar um modelo rico e expressivo que reflita as complexidades e interações do domínio. A modelagem do domínio é uma atividade colaborativa que envolve especialistas no negócio e desenvolvedores.

	2.	Bounded Contexts (Contextos Delimitados): Um Bounded Context é um limite lógico em torno de um modelo de domínio específico. É uma forma de dividir um sistema em partes menores e mais gerenciáveis, cada uma com seu próprio modelo de domínio e linguagem ubíqua (linguagem compartilhada por especialistas e desenvolvedores). Essa divisão ajuda a lidar com complexidades e a garantir que o modelo de domínio seja coerente dentro de cada contexto.

	3.	Ubiquitous Language (Linguagem Ubíqua): A Linguagem Ubíqua é uma linguagem compartilhada entre os especialistas do domínio e os desenvolvedores. É uma linguagem que descreve conceitos e processos do negócio de forma precisa e comum a todas as partes envolvidas. O uso dessa linguagem comum ajuda a evitar ambiguidades e facilita a comunicação efetiva entre todos os envolvidos no projeto.

	4.	Aggregates (Agregados): Agregados são grupos de objetos relacionados que são tratados como uma única unidade. Eles definem limites claros para a consistência e a transação no modelo de domínio. Os agregados encapsulam regras de negócio e controlam o acesso aos objetos internos. Eles são responsáveis por garantir a integridade dos dados e manter a consistência no contexto delimitado.

	O DDD oferece uma abordagem mais estruturada e orientada ao negócio para o desenvolvimento de software, permitindo que os desenvolvedores compreendam melhor o problema em questão e criem soluções


	 
    </div>
</details>

<details>
    <summary><strong>Implementação de Mocks</strong></summary>
    <br />
    <div align="left">


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


	 
    </div>
</details>


<details>
    <summary><strong>Implementação de Mocks</strong></summary>
    <br />
    <div align="left">


```bash
const entrada = gets();
```

	 
    </div>
</details>


<details>
    <summary><strong>DDD (Domain Driven Design)</strong></summary>
    <br />
    <div align="left">


```bash
const entrada = gets();
```

	 
    </div>
</details>


## 📜 License

O projeto lançado em 2023 sobre a licença [MIT](./LICENSE) ❤️ 

Made with ♥ by Shyoutarou

Gostou? Deixe uma estrelinha para ajudar o projeto ⭐