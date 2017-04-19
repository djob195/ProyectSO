extern "C"
{
    void getError(int error);
    void getMessage(char * message);
    void getStatsMessage(int ID, float stat);
    void getStatIdle(float idle);
    void allStats(float f1, float f2, float f3, float f4, float f5, float f6);
    void showcmdWindow(int window, int type);
    void showcmdQuantum(int window, int milisegundos);
}