# distribuidos-t2-udp-cliente

# Tarea#2 - Sistemas Distribuidos - Sockets UDP

En este trabajo se implementarón dos soluciones que implmentan la arquitectura Cliente-Servidor y los Sockets UDP con C#.

En la primera solucion, que incluye los programas srv y cli, se utilizó la clase UdpClient de la libreria System.Net.Sockets, para demostrar la agilidad con la que se puede implementar un socket de estas características en este lenguage. Este clase implmenta todo la lógica (Creación, Conexión, Recepción) de los sockets en cada cliente y permite enviar datagramas UDP de forma rápida.

En la segunda solución, que incluye los progrmas srv2 y cli2, se utilizaron los métodos más primitivos de la misma libreria (System.Net.Sockets) para controlar el comportamiento del dispositivo y se adicionó la capacidad de enviar mensajes de diferentes tipos. Esta aplicación permite enviar mensajes de texto y archivos (texto, audio, imagenes, etc.) de hasta 64 Kb, que es la capacidad máxima de los sockets Udp.
