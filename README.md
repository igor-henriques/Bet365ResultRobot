# **Bet365ResultRobot**

# Objetivo do Projeto
Na página https://www.bet365.com/#/AVR/B146/R^1/, obter todos os valores de odds em todos os horários, em todos os campeonatos, incluindo os valores no banco de dados sem repetição, de maneira que o site não bloqueie acesso do IP por SPAM.

# Estrutura criada
Há 4 campeonatos, portanto foram criados 4 robôs que atuam independemente um do outro. Cada robô atua sob um BackgroundService. Cada robô se comunica com uma espécie de orquestradora que foi construída em Windows Forms.
A orquestradora, por sua vez, se comunica com um singleton de configuração, permitindo modificar os valores, que são persistidos em Json no projeto. 
<br />Como no esquema:

![alt text](https://i.imgur.com/u75bzkq.png)

# Projetos
* CommonDatabase: projeto responsável por todo mapeamento do Entity Framework. Nele estão contidas todas as entidades, interfaces e repositórios referentes a acesso ao banco.
* CommonDriverExtensions: por sua vez, esse projeto é responsável por toda configuração e tudo pertinente ao chromedriver (Selenium), inclusive um repositório de manipulação de DOM.
* CommonUtils: esse projeto concentra implementações úteis a todos os projetos.
* MainRobotOrchester: orquestradora construída em Windows Forms, cujo os robôs se comunicam informando seu status e também postando as logs.

# Informações conhecidas
* A cada 3 minutos, um novo horário de jogo é inserido em cada campeonato
* Quando um jogo se inicia, sempre haverá 7 jogos disponíveis no site. Caso não haja jogo iniciado, haverão 6 jogos disponíveis.
* Cerca de 1min30 após um jogo se iniciar, ele é removido da div de horários

# Execução
O projeto atualmente já cadastra no banco de dados, sem repetição de registros, todos os dados de Odds de todos os horários, de todos os campeoantos.

# Problemas
* O site da bet365, por critério indefinido, por vezes omite os elementos referentes à mudança de horário quando o robô inicia e carrega a web, como na imagem abaixo

![alt text](https://i.imgur.com/T7hAkET.png)

Uma vez carregada corretamente a página, esse comportamento não se repete. Portanto, caso ocorra esse problema quando o software iniciar, basta reiniciar o robô até que carregue de maneira normal.

* O site do cliente se comporta de maneira estranha ao ler os registros do banco. O robô não se comunica diretamente com o site em momento algum, somente insere os dados no banco de dados de maneira única, sem repetição de registros em nenhum momento.
Ainda assim, o site repete registros de horário e apresenta uma repetição de dados que não existe em banco.

# Detalhes 
* Toda a interação com o DOM foi externalizada em .JSON de duas formas, por XPath e por CSS. No projeto, há a representação de duas classes ([ElementsXPath](https://github.com/igor-henriques/Bet365ResultRobot/blob/master/CommonDriverExtensions/Utils/XPathElements/ElementsXPath.cs), [ElementsCSS](https://github.com/igor-henriques/Bet365ResultRobot/blob/master/CommonDriverExtensions/Utils/CSSElements/ElementsCSS.cs)) que são populadas por esses Json. A motivação disso é facilitar futuras manutenções, caso mude o XPath/CSS dos elementos do site, apenas uma simples substituição no arquivo json já resolverá o problema.
* Cada instância de [WebRepository](https://github.com/igor-henriques/Bet365ResultRobot/blob/master/CommonDriverExtensions/Repositories/WebRepository.cs) implica numa janela de Chrome iniciada. Portanto, cuidado ao injetar ou instanciar a classe (que depende do contrato [IWebRepository](https://github.com/igor-henriques/Bet365ResultRobot/blob/master/CommonDriverExtensions/Interfaces/IWebRepository.cs)) em outros pontos do projeto.
* Toda construção de Odd acontece na classe [OddBuilder](https://github.com/igor-henriques/Bet365ResultRobot/blob/master/WorldCupRobot/Builders/OddBuilder.cs)
