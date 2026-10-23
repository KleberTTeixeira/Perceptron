# Perceptron — Labirinto Visual

Aplicativo de estudo de aprendizado por reforço (Q-learning) em C#  (.NET 8, Windows Forms) em que um agente aprende, por **aprendizado por reforço**, a atravessar um labirinto até o ponto de chegada. O treinamento é mostrado em tempo real: o movimento do agente, os contadores de tentativas e os gráficos dos hiperparâmetros.

## Base do estudo

O projeto é resultado do estudo do artigo:

> Horia Mania, Aurelia Guy, Benjamin Recht. *Simple random search provides a competitive approach to reinforcement learning*. University of California, Berkeley, 2018.
> arXiv:1803.07055 — https://arxiv.org/abs/1803.07055

Do artigo vêm os conceitos usados no código: ambiente (`Env`) com `Reset` e `Step`, política (`Policy`), oráculo (`Oracle`), exploração com ruído (`Noise`), episódios de exploração (`Explore`) e hiperparâmetros (`Hyperparameters`).

O artigo não está incluído neste repositório, porque a licença dele no arXiv não permite redistribuição. Ele pode ser lido no link acima.

## O que o aplicativo faz

- Exibe um labirinto de 34 × 49 células: paredes em preto, caminhos em branco, chegada em verde e o agente como um círculo vermelho.
- Ao clicar em **Start**, o agente treina por 100 episódios. Em cada episódio ele tem um limite de passos igual a 10 vezes a menor distância entre a partida e a chegada.
- Durante o treinamento a tela mostra:
  - **Tentativas**: episódio atual (total de episódios);
  - **Finalizações**: quantas vezes o agente chegou ao objetivo;
  - **Menor distância**: menor número de passos que o agente já usou para chegar (menor caminho possível);
  - valores e gráficos de **Noise**, **Learning Rate** e **Discount Factor** ao longo dos episódios.
- Depois de iniciado, o botão passa a ser **Close**, que fecha o aplicativo.

## Como funciona

### Ambiente — projeto `Maze` (`Maze/Maze.cs`)

`MazeEnv` representa o labirinto como uma matriz (`0` = caminho livre, `1` = parede).

- **Ações:** `0` parado, `1` cima, `2` baixo, `3` esquerda, `4` direita. Um movimento contra parede ou para fora do labirinto deixa o agente no lugar.
- **Distância até a chegada:** calculada por busca em largura (`FindShortestPath`).
- **Recompensa** (`CalculateReward`):
  - `+1` ao alcançar a chegada;
  - `+0,1` quando a distância até a chegada diminui;
  - `−0,1` quando a distância aumenta ou não muda;
  - `+0,2` adicional ao entrar em uma célula ainda não visitada no episódio.

### Agente e treinamento — projeto `Business` (`Business/Business.cs`)

- **`Policy`** guarda uma tabela Q (posição × ação), iniciada com `0,01` em todas as entradas.
  - Escolha da ação: com probabilidade igual ao `Noise`, uma ação aleatória (via `Oracle`). Caso contrário, a ação de maior valor Q na posição atual. Se todos os valores forem iguais, a ação também é aleatória.
- **`Training.Explore`** executa um episódio. A cada passo, a tabela Q é atualizada por:

  `Q ← Q + LearningRate × (recompensa + DiscountFactor × maxQ − Q)`

- **`Training.Train`** roda os episódios variando os hiperparâmetros ao longo do treinamento:

  | Hiperparâmetro | Faixa | Curva |
  |---|---|---|
  | Noise | 0,6 → 0,01 | desaceleração com raiz quadrada |
  | Learning Rate | 0,6 → 0,99 | aceleração linear |
  | Discount Factor | 0,7 → 0,99 | aceleração quadrática |

  Existe também um modo (`fullTypes = true`) que testa as 216 combinações das seis curvas (`TypeHP`) para os três hiperparâmetros e salva a tabela Q de cada combinação em arquivo `qTable-*.txt`. A tela atual usa o modo simples.

### Interface — projeto `LabirintoVisual` (`LabirintoVisual/Form1.cs`)

`formMaze` define o labirinto, a partida (linha 32, coluna 0) e a chegada (linha 16, coluna 38). Ela inicia o treinamento em segundo plano e redesenha continuamente o labirinto, os contadores e os gráficos.

## Estrutura

```
LabirintoVisual.sln
├─ Maze/             ambiente do labirinto
├─ Business/         política, tabela Q e treinamento (namespace Bender)
└─ LabirintoVisual/  interface Windows Forms
```

## Requisitos e execução

- Windows
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Visual Studio 2022 ou JetBrains Rider (opcional)

Abra `LabirintoVisual.sln` e execute o projeto `LabirintoVisual`. Pela linha de comando:

```
dotnet run --project LabirintoVisual
```

## Licença

© 2026 Kleber T Teixeira.

Este trabalho está licenciado sob a [Creative Commons Atribuição-NãoComercial-CompartilhaIgual 4.0 Internacional (CC BY-NC-SA 4.0)](https://creativecommons.org/licenses/by-nc-sa/4.0/). O texto completo está no arquivo [LICENSE](LICENSE).

- **Crédito obrigatório:** quem usar ou alterar deve dar crédito ao autor.
- **Uso não comercial:** é proibido usar ou vender este trabalho, ou versões alteradas dele, para fins comerciais.
- **Compartilhar igual:** versões alteradas devem ser distribuídas sob esta mesma licença.

## Como dar crédito

> Kleber T Teixeira. *Perceptron — Labirinto Visual*. 2026. Licença CC BY-NC-SA 4.0.
