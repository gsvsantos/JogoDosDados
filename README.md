# Jogo Dos Dados
Um jogo simples onde você e a CPU competem para ver quem vence a corrida.

---

## Como Jogar
1. Escolha a opção **"Começar a Partida"** no menu principal.
2. **Lance o dado** para avançar de casa.
3. A CPU irá lançar seu próprio dado **sozinha**.
4. Ganha quem ultrapassar a linha de chegada primeiro.
### Importante:
- Caso ultrapassem a linha de chegada juntos, quem estiver na maior casa vencerá.
- Caso cheguem juntos na mesma casa superior a linha de chegada, resultará em empate.

## O que o jogo tem?  
- **PvE:** Uma disputa entre o usuário e a CPU.
- **Casas Especiais:** Casas específicas que podem te ajudar ou atrapalhar.
- **Número da Sorte**: Caso tire 6 no dado, ganhará uma jogada extra.

## Requisitos
- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
  
## Tecnologias
[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet)](https://skillicons.dev)

## Como Utilizar
1. **Clone o Repositório:**
```
git clone https://github.com/gsvsantos/JogoDosDados.git
```

2. Abra o terminal ou prompt de comando e navegue até a pasta raiz do Jogo.

3. Utilize o comando abaixo para restaurar as dependências do projeto.
```
dotnet restore
```

4. Compile e execute o arquivo *.exe* do jogo.
```
dotnet build --configuration Release
```
```
JogoDosDados.ConsoleApp.exe
```

### Opcional
- Executar o projeto compilando em tempo real
```
dotnet run --project JogoDosDados.ConsoleApp
```

# Sobre o Projeto

Este projeto foi desenvolvido como parte de uma atividade da [Academia do Programador](https://www.instagram.com/academiadoprogramador/).
