# DAC-Chat
IP messender hosted as a windows service without using scokets 
Developed as a part of Course curriculum @ C-DAC Bengalore.

This is a visual studio solution with 3 projects
1) chat_client_ui is the chat client developed in WPF 
2) host creates a windows service
3) requestreply is a WCF module which has the chat functionalities

to run the project,
  import the solution into visual studios -> set start projects(multiple projects) as chat_client_ui and host.
Alternatively, download the executables folder
  run host to start the WCF service 
  run chat_client_ui to start chatting
