# AMSI Patcher

A lightweight .NET utility that patches the AMSI's `AmsiScanBuffer` function in memory to bypass scanning.

## Warning

This code is for **educational purposes only**. Disabling AMSI can expose your system to malware and is generally not recommended. Use responsibly and only in controlled environments.

## Patch Details

- **Patch bytes:** `B8 57 00 07 80 C3` (mov eax, 0x80070057; ret)
- **Return value:** `0x80070057` (AMSI_RESULT_NOT_DETECTED)

## Requirements

- Windows operating system
- .NET Framework (any version that supports P/Invoke)

## Legal

This project is intended for security research and educational purposes only. I (the author) am not responsible for any misuse of this code.
