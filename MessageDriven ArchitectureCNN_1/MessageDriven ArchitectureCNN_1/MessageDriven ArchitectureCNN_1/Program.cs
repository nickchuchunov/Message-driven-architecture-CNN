
using System.Diagnostics;
using MessageDriven_ArchitectureCNN_1.Task1;


Console.OutputEncoding = System.Text.Encoding.UTF8;
Restaurant rest = new Restaurant();

Notifications notifications = new Notifications();

notifications.NotificationsConsole(rest);