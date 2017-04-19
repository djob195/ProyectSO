#include <dos.h>
#include "utility.h"
#include <conio.h>
#define YPOSUTILITY  46
#define XPOSUTILITY  5

#define KEYWORDERROR1   "Error 1: No se ha tecleado un comando correcto"
#define KEYWORDERROR2   "Error 2: no se ha escrito un numero entero"
#define KEYWORDERROR3   "Error 3: Rango de ventana invalida, escriba un numero entre [1,6]" 
#define KEYWORDERROR4   "Error 4: el comando stats, debe tener un numero 1"  
#define MOUSEERROR5     "Error 5: Click fuera de lugar"
#define ErrorQuantum6   "Error 6: No se ha agregado la ventana al proceso"

extern "C"
{
	void clearcmd(void)
	{
		for(int i = 0; i < 72; i++)
		{
			gotoxy(XPOSUTILITY + i, YPOSUTILITY);
			cprintf(" ");
		}	
	}
    void getError(int error)
    {
	clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        switch(error)
        {
            case 1:{
                cprintf("%s",KEYWORDERROR1);
                break;
            }
            case 2:{
                cprintf("%s",KEYWORDERROR2);
                break;
            }
            case 3:{
                cprintf("%s",KEYWORDERROR3);
                break;
            }
            case 4:{
                cprintf("%s",KEYWORDERROR4);
                break;
            }
            case 5:{
		        cprintf("%s",MOUSEERROR5);
                break;
            }
            case 6:{
                cprintf("%s",ErrorQuantum6);
                break;
            }
            default: break;
        }
    }

    void getMessage(char * message){
	clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        cprintf("%s",message);
    }

    void getStatsMessage(int ID, float stat)
    {
        clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        cprintf("%d / %f",ID,stat);
    }

    void getStatIdle(float idle)
    {
        clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        cprintf("%f milisegundos",idle);
    }

    void allStats(float f1, float f2, float f3, float f4, float f5, float f6)
    {
        clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        cprintf("%d / %f, %d / %f, %d / %f, %d / %f, %d / %f, %d / %f", 1, f1, 2, f2, 3, f3, 4, f4, 5, f5, 6, f6);
    }
    void showcmdWindow(int window, int type)
    {
        clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        if(type == 1)
        {
            cprintf("Se ha agregado la ventana %d",window);
        }
        else if (type == 2)
        {
            cprintf("Se ha pausado la ventana %d",window);
        }
        else if (type == 3)
        {
            cprintf("Se ha dado play a la ventana %d",window);
        }
        else if (type == 4)
        {
            cprintf("Se ha removido la ventana %d",window);
        }
        else
        {
            cprintf("Se ha limpiado la ventana %d",window);
        }
    }
    void showcmdQuantum(int window, int milisegundos)
    {
        clearcmd();
        gotoxy(XPOSUTILITY,YPOSUTILITY);
        cprintf("Se ha colocado un quantum de %d segundos a la ventana %d", milisegundos,window);
    }
}