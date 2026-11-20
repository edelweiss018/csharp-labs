#include <stdio.h>
#include <stdlib.h>
 
#define n 3
#define N (2*n)
 
void print_matrix(int m[N][N])
{
    int i, j;
    for (i = 0; i < N; i++) {
        for (j = 0; j < N; j++)
            printf("%3d", m[i][j]);
        printf("\n");
    }
}
 
void copy_matrix(int s[N][N], int d[N][N])
{
    int i, j;
    for (i = 0; i < N; i++)
        for (j = 0; j < N; j++)
            d[i][j] = s[i][j];
}
 
int main()
{
    int a[N][N], b[N][N], c[N][N];
    int i, j, k, tmp, imin;
 
    srand(7);
    for (i = 0; i < N; i++)
        for (j = 0; j < N; j++)
            a[i][j] = rand() % 10;
 
    printf("Generated matrix:\n");
    print_matrix(a);
 
    /* ---- A: blocks swap (1<->4, 2<->3) ---- */
    for (i = 0; i < N; i++)
        for (j = 0; j < N; j++)
            b[i][j] = a[(i + n) % N][(j + n) % N];
    printf("\nA: new matrix (blocks swapped):\n");
    print_matrix(b);
 
    /* ---- B a) anti-diagonal, simple exchange ---- */
    copy_matrix(b, c);
    for (i = 0; i < N - 1; i++)
        for (j = 0; j < N - 1 - i; j++)
            if (c[j][N-1-j] > c[j+1][N-2-j]) {
                tmp = c[j][N-1-j];
                c[j][N-1-j] = c[j+1][N-2-j];
                c[j+1][N-2-j] = tmp;
            }
    printf("\nB a): anti-diagonal sorted (exchange):\n");
    print_matrix(c);
 
    /* ---- B b) main diagonal, simple selection ---- */
    copy_matrix(b, c);
    for (i = 0; i < N - 1; i++) {
        imin = i;
        for (j = i + 1; j < N; j++)
            if (c[j][j] < c[imin][imin])
                imin = j;
        tmp = c[i][i];
        c[i][i] = c[imin][imin];
        c[imin][imin] = tmp;
    }
    printf("\nB b): main diagonal sorted (selection):\n");
    print_matrix(c);
 
    /* ---- B c) first row, simple insertion ---- */
    copy_matrix(b, c);
    for (i = 1; i < N; i++) {
        tmp = c[0][i];
        for (k = i - 1; k >= 0 && c[0][k] > tmp; k--)
            c[0][k+1] = c[0][k];
        c[0][k+1] = tmp;
    }
    printf("\nB c): first row sorted (insertion):\n");
    print_matrix(c);
 
    return 0;
}

