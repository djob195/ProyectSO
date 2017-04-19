#include <dos.h>
#include <conio.h>
#include "mouse.h"

#define MOUSEINTERRUPT 0x33
extern "C"
{
	struct mData isClicked (void)
	{
		mData mouseData;
		union REGS in, out;
		in.x.ax = 3;
		int86 (0X33,&in,&out);
		if (out.x.bx == 1)
		{
			mouseData.mouseX = ((int)out.x.cx/8) + 1;
			mouseData.mouseY = ((int)out.x.dx/8) + 1;
			mouseData.isClick = 1;

		}
		else
		{
			mouseData.isClick = 0;
		}
		return mouseData;
	}
int ResetRaton()
{
	union REGS regin, regout;
	regin.x.ax = 0;
	int86(0x33, &regin, &regout);
	if((int)regout.x.ax == 0)
	{
		return -1;
	}
	else
	{
		regin.x.ax = 1;
		int86(0x33, &regin, &regout);
	}
	return 1;
}
}