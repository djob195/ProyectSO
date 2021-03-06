#define INTTECL 0x16 // N? de interrupci?n de teclado (BIOS)
#define ZF 64
#define YPOS 42
#define XMINPOS 5
#define XMAXPOS 76
#define MAXCHARSCREEN 72
#define MK_WORD(HIBYTE,LOBYTE) (int)((HIBYTE << 8) + LOBYTE)
#include <dos.h>
#include <conio.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include "keyword.h"
#include "utility.h"

extern "C"
{
	int xpos = XMINPOS;
	char commands [72];
	struct tokenRead  tomaToken(char * input)
	{	
		tokenRead  token;
		if(*input == '\0')
		{
			token.word = 0;
			token.type = -1;
			token.pointer =  input;	
			token.num = 0;
			return token;
		}
		int contadorCaracter = 0;
		char word[7] = "";
		int state = 0;
		int flagExit = 0;
		int countDigits = 0;
		while(*input == ' ' || *input== '\t')
		{
			input++;
		}
		while(flagExit == 0)
		{
			if (state == 0)
			{
				if(('a' <= *input) && (*input<= 'z'))
				{
					state = 1;
				}
				else if(*input == '-')
				{
					state = 2;
				}
				else if(('0' <= *input) && (*input <= '9'))
				{
					countDigits++;
					state = 3;
				}
				else
				{
					flagExit = 1;
				}
			}
			else if (state == 1)
			{
				if(('a' <= *input) && (*input <= 'z'))
				{
					state = 1;
				}
				else if (*input == ' '|| *input== '\0')
				{
					state = 1;
					flagExit = 1;
				}
				else
				{
					state = 0;
					flagExit = 1;
				}
			}
			else if (state == 2)
			{
				flagExit = 1;
			}
			else
			{	
				if(('0' <= *input) && (*input <= '9'))
				{
					countDigits++;
					state = 3;
				}
				else if (*input == ' ' || *input== '\0')
				{
					state = 3;
					flagExit = 1;
				}
				else
				{
					state = 0;
					flagExit = 1;
				}
			}
			if(flagExit == 0)
			{
				if (contadorCaracter < 7)
				{
					char car[1];
					car[0]= *input;
					car[1]='\0';
					strcat(word,car );
					input++;
				}
				else
				{
					token.word = 0;
					token.type = -1;
					token.pointer =  input;
					return token;
				}
			}
		};
		if(state == 3)
		{
			if(countDigits>7)
			{
				token.word = 0;
				token.type = -1;
				token.pointer =  input;
				return token;
			}
			token.num = atoi(word);
		}			
		token.type = state;
		token.word = word;
		token.pointer =  input;
		return token;
	}

	int inWindow (struct tokenRead token)
	{
		int window = token.num;
		if ((window < 1) || (window > 6))
		{
			return -3;
		}
		window--;
		return window;
	}

	struct structComand selectAction(void)
	{
		char* command;
		struct structComand comando;
		comando.type = 0;
		comando.window= 0;
		comando.quantum=0;
		comando.stats = 0;
		int window = 0;
		char* prueba = &commands[0];
		prueba = strlwr(prueba);
		struct tokenRead token = tomaToken(prueba);
		prueba = token.pointer;
		if(token.type == 1)
		{
			int action = 0;
			if (strcmp(token.word,"quantum") ==0)
			{
				token =  tomaToken(prueba);
				prueba = token.pointer;
				if (token.type !=3)
				{
					getError(2);
					return comando;
				}
				window = inWindow(token);
				if(window < 0)
				{
					window *= -1;
					getError(window);
					return comando;
				}
				token =  tomaToken(prueba);
				prueba = token.pointer;
				int quantum = token.num;
				comando.type = 6;
				comando.window= window;
				comando.quantum=quantum;
			}
			else if (strcmp(token.word,"stats") ==0)
			{
				token =  tomaToken(prueba);
				prueba = token.pointer;
				char isPositive = '+';
				int status = 0;
				if (token.type == 2)
				{
					token =  tomaToken(prueba);
					prueba = token.pointer;
					isPositive = '-';
				}
				if (token.type !=3)
				{
					getError(2);
					return comando;
				}
				int stats = token.num;
				if (stats < 0 || stats > 6)
				{
					getError(2);
					return comando;
				}
				if (isPositive=='-')
				{
					stats *=-1;
				}				
				comando.type = 7;
				comando.stats = stats;
			}
			else if (strcmp(token.word,"exit") ==0)
			{
				comando.type = 8;
			}
			else
			{
				if(strcmp(token.word,"add") ==0)
				{
					comando.type = 1;
				}
				else if (strcmp(token.word,"pause") ==0)
				{
					comando.type = 2;
				}
				else if (strcmp(token.word,"play") ==0)
				{
					comando.type = 3;
				}	
				else if (strcmp(token.word,"remove") ==0)
				{
					comando.type = 4;
				}
				else if (strcmp(token.word,"clear") ==0)
				{
					comando.type = 5;
				}
				else
				{
					getError(1);
					return comando;
				}
				token = tomaToken(prueba);
				prueba = token.pointer;
				window = inWindow(token);
				if(window  < 0)
				{
					window *= -1;
					getError(window);
					return comando;
				}
				comando.window= window;
			}
		}
		else
		{
			getError(1);
		}		
		return comando;
	}
	int desplazamientoPuntero()
	{
		return xpos -XMINPOS;
	}
	void cleanScreen()
	{
		for(int i = 0; i < MAXCHARSCREEN; i++)
		{
			gotoxy(XMINPOS + i,YPOS);
			commands[i] = 0;
			cprintf(" ");
		}
		xpos = XMINPOS;
		gotoxy(XMINPOS,YPOS);
	}
	struct structComand isKeyPress()
	{
		struct structComand comando;
		comando.type = 0;
		comando.window= 0;
		comando.quantum=0;
		comando.stats = 0;
		gotoxy(xpos,YPOS);
		if(kbhit()!=0)
		{
			char caracter = getche();
			if(caracter == 13)
			{
				comando=selectAction();
				cleanScreen();
			}
			else if(caracter == 8)
			{
				if(xpos > XMINPOS )
				{
					xpos--;
					int i = desplazamientoPuntero();
					commands[i] = ' ';
					gotoxy(xpos,YPOS);
					cprintf(" ");
				}
			}
			else 	
			{	
				int i = desplazamientoPuntero();
				commands[i] = caracter;
				if(xpos < XMAXPOS )
				{
					xpos++;
				}	
			}
		}
		return comando;
	}
}