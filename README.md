Escrita Concorrente em Arquivo com Threads (C#)

Este projeto foi desenvolvido para demonstrar um problema comum em programação concorrente, quando várias threads acessam o mesmo recurso ao mesmo tempo.

O programa cria 20 threads, e cada uma delas escreve 500 linhas em um arquivo de texto, totalizando 10.000 linhas.

O objetivo é comparar dois cenários:

Escrita sem controle de concorrência Escrita com seção crítica usando lock Funcionamento do Programa

Cada thread executa a mesma função:

Gera uma linha de texto contendo o ID da thread Escreve essa linha em um arquivo Repete esse processo 500 vezes

Como são 20 threads, o total esperado no arquivo é:

20 threads × 500 linhas = 10000 linhas

-Com Seção Crítica

Na segunda versão foi utilizada uma seção crítica usando lock, que garante que apenas uma thread por vez possa escrever no arquivo.

Trecho do código:

lock (trava) { writer.WriteLine(linha); }

Com isso, o acesso ao arquivo passa a ser controlado, evitando que várias threads escrevam ao mesmo tempo.

Assim, o arquivo é gerado corretamente com as 10.000 linhas esperadas.
