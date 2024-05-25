# 3SS Tutorial

- [3SS Tutorial](#3ss-tutorial)
  - [Communication Key](#communication-key)
    - [Matrices](#matrices)
    - [Timezone Codes](#timezone-codes)
    - [Plaintext Codes](#plaintext-codes)
    - [Format](#format)
  - [Encode](#encode)
    - [1. Hill Cipher](#1-hill-cipher)
    - [2. Rail Fence](#2-rail-fence)
    - [3. Affine](#3-affine)
    - [4. Output](#4-output)
  - [Decode](#decode)
    - [1. Reading the Communication Key](#1-reading-the-communication-key)
    - [2. Affine](#2-affine)
    - [3. Rail Fence](#3-rail-fence)
    - [4. Hill Cipher](#4-hill-cipher)
  - [Statistics](#statistics)

---

## Communication Key
The communication key (or $CK$) is the 8-character combination used to tell the application what specifications to use. This is decided by the encoders and decoders as soon as the Dark Agent has left. The $CK$ should be known between both teams. There should be a safe way to not only communicate it with the other team, but also a safe way to remember or write it somewhere. This communication must be discrete, as if it's revealed, then all ciphertext becomes vulnerable.

### Matrices
First, select a random matrix from the table below. That matrix will become the encoding matrix for the [Hill Cipher](#1-hill-cipher) step of 3SS. The matrix code used for the communication key will be the matrix's column then row. For example, $A1$ would correspond to the matrix in Column A, row 1. This code will become the $(Matrix)$ portion of the communication key. The inverse matrix is calculated by the computer of the Decoders.

$$
\begin{array}{c|c|c|c|c|c}
\textbf{Matrix} & A & B & C & D & E \\
\hline
  0 & 
  \begin{bmatrix} 2 & 26 \\
  18 & 28 \end{bmatrix} &
  \begin{bmatrix} 7 & 18 \\
  27 & 6 \end{bmatrix} &
  \begin{bmatrix} 5 & 26 \\
  28 & 21 \end{bmatrix} &
  \begin{bmatrix} 4 & 4 \\
  7 & 5 \end{bmatrix} &
  \begin{bmatrix} 28 & 11 \\
  13 & 18 \end{bmatrix} \\
\hline
  1 & 
  \begin{bmatrix} 12 & 19 \\
  13 & 18 \end{bmatrix} &
  \begin{bmatrix} 22 & 9 \\
  3 & 12 \end{bmatrix} &
  \begin{bmatrix} 27 & 19 \\
  14 & 26 \end{bmatrix} &
  \begin{bmatrix} 15 & 28 \\
  28 & 6 \end{bmatrix} &
  \begin{bmatrix} 20 & 2 \\
  0 & 16 \end{bmatrix} \\
\hline
  2 & 
  \begin{bmatrix} 8 & 27 \\
  20 & 17 \end{bmatrix} &
  \begin{bmatrix} 4 & 11 \\
  6 & 27 \end{bmatrix} &
  \begin{bmatrix} 11 & 3 \\
  2 & 16 \end{bmatrix} &
  \begin{bmatrix} 0 & 16 \\
  23 & 21 \end{bmatrix} &
  \begin{bmatrix} 15 & 11 \\
  14 & 7 \end{bmatrix} \\
\hline
  3 & 
  \begin{bmatrix} 15 & 22 \\
  15 & 21 \end{bmatrix} &
  \begin{bmatrix} 22 & 16 \\
  6 & 28 \end{bmatrix} &
  \begin{bmatrix} 3 & 12 \\
  14 & 7 \end{bmatrix} &
  \begin{bmatrix} 15 & 27 \\
  6 & 15 \end{bmatrix} &
  \begin{bmatrix} 14 & 10 \\
  3 & 0 \end{bmatrix} \\
\hline
  4 & 
  \begin{bmatrix} 8 & 8 \\
  21 & 2 \end{bmatrix} &
  \begin{bmatrix} 8 & 5 \\
  21 & 10 \end{bmatrix} &
  \begin{bmatrix} 5 & 22 \\
  27 & 7 \end{bmatrix} &
  \begin{bmatrix} 12 & 10 \\
  13 & 8 \end{bmatrix} &
  \begin{bmatrix} 6 & 21 \\
  2 & 18 \end{bmatrix} \\
\hline
  5 & 
  \begin{bmatrix} 23 & 1 \\
  20 & 20 \end{bmatrix} &
  \begin{bmatrix} 25 & 12 \\
  1 & 7 \end{bmatrix} &
  \begin{bmatrix} 4 & 22 \\
  17 & 1 \end{bmatrix} &
  \begin{bmatrix} 11 & 25 \\
  24 & 25 \end{bmatrix} &
  \begin{bmatrix} 18 & 2 \\
  21 & 6 \end{bmatrix} \\
\hline
  6 & 
  \begin{bmatrix} 14 & 5 \\
  21 & 7 \end{bmatrix} &
  \begin{bmatrix} 11 & 1 \\
  24 & 24 \end{bmatrix} &
  \begin{bmatrix} 9 & 8 \\
  8 & 22 \end{bmatrix} &
  \begin{bmatrix} 13 & 25 \\
  19 & 26 \end{bmatrix} &
  \begin{bmatrix} 7 & 21 \\
  1 & 2 \end{bmatrix} \\
\hline
  7 & 
  \begin{bmatrix} 1 & 10 \\
  1 & 17 \end{bmatrix} &
  \begin{bmatrix} 10 & 28 \\
  13 & 0 \end{bmatrix} &
  \begin{bmatrix} 26 & 19 \\
  25 & 4 \end{bmatrix} &
  \begin{bmatrix} 18 & 7 \\
  3 & 28 \end{bmatrix} &
  \begin{bmatrix} 8 & 16 \\
  21 & 23 \end{bmatrix} \\
\hline
  8 & 
  \begin{bmatrix} 25 & 20 \\
  7 & 16 \end{bmatrix} &
  \begin{bmatrix} 0 & 10 \\
  4 & 22 \end{bmatrix} &
  \begin{bmatrix} 1 & 18 \\
  23 & 16 \end{bmatrix} &
  \begin{bmatrix} 11 & 6 \\
  8 & 12 \end{bmatrix} &
  \begin{bmatrix} 16 & 16 \\
  17 & 22 \end{bmatrix} \\
\hline
  9 &
  \begin{bmatrix} 0 & 28 \\
  25 & 0 \end{bmatrix} &
  \begin{bmatrix} 22 & 7 \\
  9 & 4 \end{bmatrix}
\end{array}
$$

### Timezone Codes
Then, assign the two encoders. Depending on who they are, there will be a specific time zone code. This numbers listed in the table below are used in the [Rail Fence](#2-rail-fence) and [Affine](#3-affine) steps of 3SS, as they represent the timezones of each person's native country relative to UTC. To create the code, first find the first encoder's corresponding $Letter$, and then have them decide whether they want Daylight Savings applied. If they don't apply DST, then add a $0$ to the end of the letter. Otherwise, add a $1$. This is the first encoder's timezone code. For example, if **Ben** was the first encoder and he decided to apply DST, then his timezone code would be $A1$. The process is the same for the second encoder's timezone code, instead using their own corresponding $Letter$. These two codes comprise the $(\text{Timezone 1})$ and $(\text{Timezone 2})$ portions of the communication key. Calculations are made with these numbers on both the encoders' and decoders' computers.

$$
\begin{array}{c|c|c|c}
\textbf{Name}&Letter&0&1\\
\hline
Ben&A&+8&+9\\
\hline
Ember&B&+1&+2\\
\hline
Manny&C&-4&-3\\
\hline
Stacey&D&-5&-4\\
\hline
Viktorija&E&+2&+3
\end{array}
$$

### Plaintext Codes
Then, select a random column and row, and the corresponding letter will be the correct plaintext that will be read by the decoders. This is crucial in the [Output](#4-output) step of 3SS. The plaintext code will be the location of the cell you chose, being column followed by row. For example, $B2$ corresponds to $A$, meaning the decoders will ignore the two other plaintexts and focus on plaintext $A$. The Plaintext Code will be read by the decoders.

$$
\begin{array}{c|c|c|c}
\textbf{Plaintext}&A&B&C\\
\hline
    0&A&C&B\\
\hline
    1&B&A&C\\
\hline
    2&B&C&A\\
\hline
    3&C&A&B\\
\hline
    4&C&B&A\\
\end{array}
$$

### Format
Finally, the way to format the Communicaiton key is simple. Take all four codes, join them together, and then convert them to decimal from a hex number. Once you have devised the decimal number, it may be communicated with both the encoding and decoding teams. The format will look like below.

$$
\text{[Matrix][Timezone 1][Timezone 2][Plaintext]}_{16}\rightarrow\text{Decimal}
$$

- #### Ex. 1
  - **Matrix** - A1
  - **Timezone 1** - Encoder 1 is Ben
    - **DST** - No
  - **Timezone 2** - Encoder 2 is Ember
    - **DST** - Yes
  - **Plaintext** - B1

$$ 
CK = A1A0B1B1_{16}= 2711663025_{10} 
$$

- #### Ex. 2
  - **Matrix** - C5
  - **Timezone 1** - Encoder 1 is Stacey
    - **DST** - Yes
  - **Timezone 2** - Encoder 2 is Manny
    - **DST** - No
  - **Plaintext** - A3

$$ 
CK = C5D1C0A3_{16}= 3318857891_{10} 
$$

---

## Encode

### 1. Hill Cipher
### 2. Rail Fence
### 3. Affine
### 4. Output

---

## Decode

### 1. Reading the Communication Key
### 2. Affine
### 3. Rail Fence
### 4. Hill Cipher

---

## Statistics

<h4 style="text-align: center;">Combinations from Communication Key</h4>

<h4 style="text-align: center;">Combinations from Hand Encoding</h4>