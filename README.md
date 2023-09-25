# The Legend Of Vaati Tutorial Of Destiny - UFSCar Lesson of Data Structure

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Inicial.png)

Video-Teaser: https://www.youtube.com/watch?v=6_ldRaMAkuQ

# Ideia
A ideia era criar um jogo que utilizasse diversas estruturas de dados, com isso em mente, utilizamos 3 estruturas: Pilha, Fila e Lista.
Um gênero de jogo que se adequa a essas estruturas são os RPGs, e portanto, criamos um jogo zelda-like.

# Como as estruturas foram utilizadas
## Sistema de Dash

Para a estrutura de Pilha, criamos o sistema de stamina para ser utilizado, basicamente, no inicio do jogo é necessário pisar em duas plataformas em um determinado tempo, e isso só é possível utilizando um dash (corrida).

Cada vez que se utiliza o dash, retira-se 3 objetos vazios da pilha, e é acrescentado 1 objeto vazio a cada segundo na pilha. Os objetos são meramente ilustrativos, o que queremos de fato é a contagem da pilha para saber quanto temos de stamina.

Abaixo temos algumas imagens exemplos:

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Stamina%20half.png)
![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Stamina%20enchendo.png)

## Sistema de Puzzle

Para a utilização de fila, pensamos em um puzzle o qual o computador nos dá uma sequência e o jogador necessita repetir essa mesma sequência. Em outras palavras, o jogador necessita preencher a fila da mesma forma que a máquina, e no fim é checado a igualdade.

A sequência é feita visualmente pelos fogos.

Abaixo temos algumas imagens:

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Puzzle.png)
![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Puzzle1.png)

## Sistema de Inventário

Para a utilização da lista, criamos uma quest que o mercador troca uma determinada quantidade de rupees (moeda do jogo) pela chave que desbloqueia a parte final do jogo. 

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Need%20Check.png)

Para tal seria necessário armazenar as rupees, assim foi criado o inventário. 

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Backpack.png)

E claro, não seria zelda-like se não pudessemos quebrar os jarros:

![Stack](https://github.com/dahiwas/TheLegendOfVaatiTutorialOfDestiny/blob/main/stacks/Jars.png)

# Conclusão

E dessa forma criamos esse jogo utilizando o Software Unity com a linguagem C# sendo como objetivo principal a implementação dessas estruturas de dados, em relação a parte aúdio-visual, a Nintendo detém todos os direitos, mas também editamos alguns detalhes de pixelart com o software AseSprite. Já o video introdutório foi utilizado o software Adobe Premier.  
