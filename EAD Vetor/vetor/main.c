#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char numeroEntrada[6];
    int vetor[5]={0};
    int tamanho,a, i=0;

    scanf("%s", numeroEntrada);

    tamanho = strlen(numeroEntrada); //mesma logica do jogo de texto
    a = 5 - tamanho;

    for(i = 0; i < tamanho; i++)
    {
       vetor[a+i] = numeroEntrada[i] - '0'; //isso precisei pesquisar muito no google pra achar a conversão, unica dificuldade do codigo.
    }

    for(i = 0; i < 5; i++)
    {
    printf("%d", vetor[i]);
        if (i < 4)
        {
           printf(",");
        }
    }

    return 0;
}
