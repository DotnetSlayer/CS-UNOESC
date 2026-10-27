import os
import time
from concurrent.futures import ProcessPoolExecutor

LIMITE = 10_000_000

def eh_primo(numero):
    if numero < 2:
        return False
    if numero == 2:
        return True
    if numero % 2 == 0:
        return False

    divisor = 3
    while divisor * divisor <= numero:
        if numero % divisor == 0:
            return False
        divisor += 2

    return True

def contar_primos(inicio, fim):
    quantidade = 0
    for numero in range(inicio, fim + 1):
        if eh_primo(numero):
            quantidade += 1
    return quantidade

def dividir_intervalo(limite, quantidade):
    tamanho = limite // quantidade
    intervalos = []

    for i in range(quantidade):
        inicio = i * tamanho + 1
        fim = limite if i == quantidade - 1 else (i + 1) * tamanho
        intervalos.append((inicio, fim))

    return intervalos

def executar_sequencial():
    inicio = time.perf_counter()
    resultado = contar_primos(1, LIMITE)
    tempo = time.perf_counter() - inicio
    return resultado, tempo

def executar_paralelo(workers):
    intervalos = dividir_intervalo(LIMITE, workers)
    inicio = time.perf_counter()

    with ProcessPoolExecutor(max_workers=workers) as executor:
        tarefas = [
            executor.submit(contar_primos, inicio_i, fim_i)
            for inicio_i, fim_i in intervalos
        ]
        resultado = sum(tarefa.result() for tarefa in tarefas)

    tempo = time.perf_counter() - inicio
    return resultado, tempo

def main():
    print("=" * 70)
    print("CONTAGEM DE NÚMEROS PRIMOS")
    print("=" * 70)
    print(f"Limite: {LIMITE:,}".replace(",", "."))
    print(f"Processadores lógicos: {os.cpu_count()}")

    resultado_seq, tempo_seq = executar_sequencial()

    print("\nSEQUENCIAL")
    print(f"Primos: {resultado_seq}")
    print(f"Tempo: {tempo_seq:.4f} s")

    resultados = []

    for workers in [2, 4, 8]:
        resultado, tempo = executar_paralelo(workers)
        speedup = tempo_seq / tempo
        eficiencia = speedup / workers * 100

        resultados.append((workers, resultado, tempo, speedup, eficiencia))

        print(f"\nPARALELO - {workers} PROCESSOS")
        print(f"Primos: {resultado}")
        print(f"Tempo: {tempo:.4f} s")
        print(f"Speedup: {speedup:.2f}x")
        print(f"Eficiência: {eficiencia:.2f}%")

    print("\nRESULTADO FINAL")
    print("Resultado esperado: 664579")
    print(f"Resultado sequencial: {resultado_seq}")

    for workers, resultado, tempo, speedup, eficiencia in resultados:
        print(
            f"{workers} processos | {resultado} primos | "
            f"{tempo:.4f}s | {speedup:.2f}x | {eficiencia:.2f}%"
        )

if __name__ == "__main__":
    main()
