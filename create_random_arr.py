import random
import os
import time


def main(array_len, file):
    if os.path.exists(file): os.remove(file)
    
    f = open(file, "w")
    f.write(f"{array_len} ")
    [f.write(f"{random.randint(0, array_len)} ") for _ in range(array_len)]

if __name__ == "__main__":
    
    ARRAY_LEN = "1 000 000"
    FILE = "rand_arr.txt"

    start_time = time.time()
    main(int(ARRAY_LEN.replace(" ", "")), FILE)
    end_time = time.time()
    
    print("Execution time:", round(end_time - start_time, 3), "seconds to create: ", ARRAY_LEN, " numbers")
