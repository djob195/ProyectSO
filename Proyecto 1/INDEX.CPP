#include <conio.h>
#include <dos.h>
#include<stdlib.h>
#include "mouse.h"
#include "render.h"
#include "keyword.h"
#include "utility.h"

#define INTTICK 0X1C    /* The clock tick   interrupt */
#ifdef __cplusplus
    #define __CPPARGS ...
#else
    #define __CPPARGS
#endif


float countClock=0;
float countIdle = 0;
int exitt = 0;
int turno = 0;
struct PCB
{
	int screenPcb [24][18];
	int Live;
	int Play;
	int ID;
	float Quantum;	
	int contador;
	int nowCaracter;
};
PCB pcbs [6];
void paintSCREEN(int ID,int x, int y, int COLOR)    
{
        x++;
        y++;
	x= ((ID%3)*25) + (x+3);
	y = ((ID/3)*19) + (y+2);
        gotoxy(x,y);
    	textbackground(COLOR);
    	cprintf(" ");
	textbackground(BLACK);
}

void clean(int ID)
{
	for (int i = 0; i <24; i++)
	{
	    for (int j = 0; j < 18; j++)
	    {
		pcbs[ID].screenPcb[i][j]=0;
		paintSCREEN(ID, i, j, BLACK);    
	    }
	}
}

int isLive(int ID)
{
	if(pcbs[ID].Live==1)
	{
		return 1;
	}		
	return 0;
}

int isPlay(int ID)
{
	if(pcbs[ID].Play==1)
	{
		return 1;
	}		
	return 0;
}

int isWork(int ID)
{
	if( (isLive(ID)==1) && (isPlay(ID)==1) && (pcbs[ID].Quantum >= countClock) )
	{
		return 1;
	}		
	return 0;
}

void setQuantum(int ID,int quantum)
{
	pcbs[ID].Quantum = quantum*0.018206;
}

void activeScreen(int ID, int x, int y)
{
	if( (isLive(ID)==1))
	{
		pcbs[ID].screenPcb[x][y]=1;
	}	
}

void painted(int ID,int x, int y, int color)
{
	if(pcbs[ID].screenPcb[x][y]==1)
    {
	    paintSCREEN(ID,x,y,color);
     }
}

void blinkPCB()
{
	if(isWork(turno) == 0)
	{
		return;
	}
	int cl = 0;
	if(pcbs[turno].nowCaracter == 1)
	{
		cl = BLUE;	
		pcbs[turno].nowCaracter = 0;
	}
	else
	{
		cl = BLACK;
		pcbs[turno].nowCaracter = 1;
	}
	for (int i = 0; i <24; i++)
	{
	    for (int j = 0; j < 18; j++)
	    {
			painted(turno,i,j,cl); 
	    }
	}
}

void interrupt (*oldhandler)(__CPPARGS);
void interrupt handler(__CPPARGS)
{
	   disable();
	   countClock+=0.018206;
	   if(isWork(turno) == 1)
	   {
			countIdle=0;
			pcbs[turno].contador++;
	   }
	   else
	   {
		   countClock = 0;
		   countIdle+=0.018206;
		   turno++;
		   if(turno > 6)
		   {
			   turno = 0;
		   }
	   }
	   enable();
	   oldhandler();
}

void startClock(void)
{
	oldhandler = getvect(INTTICK);
	setvect(INTTICK, handler);
}

void stopClock(void)
{
	setvect(INTTICK, oldhandler);
}

void startPCBs(void)
{
	for(int i = 0; i < 6; i++)
 	{
		pcbs[i].ID = i;
	}
}

void getDataClick(mData mouseData,RenderKernel *render)
{
	if(mouseData.isClick == 1)
	{
		pointPCB point;
		point=render->getPointZ(mouseData.mouseX, mouseData.mouseY);
		if(point.error== 0)
		{
			activeScreen(point.z,point.x,point.y);
		}
		else
		{
			if(point.error != 0)
			{
				int error = point.error*-1;
				getError(error);
			}
		}
	}					
}

float getStatsPCB(int ID)
{
	int totalCounts = 0;
	for	(int i = 0; i < 6; i++)
	{
		totalCounts+=pcbs[i].contador;
	}
	if(totalCounts < 1)
	{
		return 0;
	}
	float stat = pcbs[ID].contador * 100 / totalCounts;
	return stat;
}

float getIdle()
{
	float idleTotal = countIdle /0.018206;
	return idleTotal;
}
void getDataKeyword(struct structComand cmd)
{
	if(cmd.type > 0 )
	{
		if(cmd.type == 1)
		{
			pcbs[cmd.window].Live = 1;
			pcbs[cmd.window].Play = 1;
			pcbs[cmd.window].contador = 0;
			showcmdWindow(cmd.window,1);
		}
		else if(cmd.type  == 2)
		{
			if(isLive(cmd.window)==1)
			{
				pcbs[cmd.window].Play = 0;
				showcmdWindow(cmd.window,2);
			}
			else
			{
				getError(6);
			}
		}
		else if(cmd.type  == 3)
		{
			if(isLive(cmd.window)==1)
			{
				pcbs[cmd.window].Play = 1;
				showcmdWindow(cmd.window,3);
			}
			else
			{
				getError(6);
			}
		}
		else if(cmd.type  == 4)
		{
			if(isLive(cmd.window)==1)
			{
				pcbs[cmd.window].Live = 0;
				pcbs[cmd.window].Play = 0;
				pcbs[cmd.window].contador = 0;
				showcmdWindow(cmd.window,4);
			}
			else
			{
				getError(6);
			}
		}
		else if(cmd.type  == 5)
		{
			clean(cmd.window);
			showcmdWindow(cmd.window,5);
		}
		else if(cmd.type  == 6)
		{
			if(isLive(cmd.window)==1)
			{
				setQuantum(cmd.window,cmd.quantum);
				showcmdQuantum(cmd.window, cmd.quantum);
			}
			else
			{
				getError(6);
				return;
			}
		}
		else if(cmd.type  == 7)
		{
			if(cmd.stats == -1)
			{
				float idle =  getIdle();
				getStatIdle(idle);
			}
			else if(cmd.stats == 0)
			{
				float f1,f2,f3,f4,f5,f6;
				f1 = getStatsPCB(1);
				f2 = getStatsPCB(2);
				f3 = getStatsPCB(3);
				f4 = getStatsPCB(4);
				f5 = getStatsPCB(5);
				f6 = getStatsPCB(6);
				allStats(f1,f2,f3,f4,f5,f6);
			}
			else
			{
				float f = getStatsPCB(cmd.stats);
				getStatsMessage(cmd.stats, f);
			}
		}
		else
		{
			exitt = 1;
		}
	}
}

int main(void)
{
	startPCBs();
	ResetRaton();
	RenderKernel *render = new RenderKernel();
	startClock();
	struct mData mouseData;
	struct structComand cmd;
	while (exitt==0)
	{
		mouseData = isClicked();
		getDataClick(mouseData,render);
		cmd=isKeyPress();
		getDataKeyword(cmd);
		blinkPCB();
	}
	stopClock();
	return 0;
}