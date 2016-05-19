﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    public class StartMenu
    {
         public static void drawSplashScreen()
        {
           // Console.SetWindowSize(100,50);
           // Console.BufferHeight = 500;
            // Console.BufferWidth = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                                                    '@@                                                                   ");
            Console.WriteLine("                                                                    #@@                                                                   ");
            Console.WriteLine("                                                                    @@@                                                                   ");
            Console.WriteLine("                                                                    @@@                                                                  ");
            Console.WriteLine("                                                                    @@@                                                                  ");
            Console.WriteLine("                                                                    @@@.                                                                 ");
            Console.WriteLine("                                                                   `@@@,                                                                 ");
            Console.WriteLine("                                                              .;@@ .@@@; @@#,`                                                           ");
            Console.WriteLine("                                                          .'@@@@@@ .@@@# #@@@@@#;                                                        ");
            Console.WriteLine("                                                         @@@@@@@@ ;@@@@ +@@@@@@@;                                                        ");
            Console.WriteLine("                                                         ,@@@@@@@@ +: ,' :@@@@@@@@                                                       ");
            Console.WriteLine("                                                         #@@@@@#,`        .'@@@@@@,                                                      ");
            Console.WriteLine("       @.                                               `@@@.       ,+'`      `+@@#                                                `@    ");
            Console.WriteLine("       @@@+                                             , `     ,@@@@@@@@@+`                                                     +@@@    ");
            Console.WriteLine("      +@@@@@@`                                             `:@@@@@@@@@@@@@@@@@'.                                              `@@@@@@+   ");
            Console.WriteLine("      @@@@@@@@@;                                       `;@@@@@@@@@@@@@@@@@@@@@@@@@',                                        ;@@@@@@@@@   ");
            Console.WriteLine("      `.@@@@@@@@@@`                                 +@@@@@@@@@@@@@'     `@@@@@@@@@@@@@@,                                 `@@@@@@@@@@.`   ");
            Console.WriteLine("         ,@@@@@@@@@@'                          `+@@@@@@@@@@@@#;             `'@@#@@@@@@@@@@,`                          '@@@@@@@@#@,      ");
            Console.WriteLine("           :@@@@@@@@@@#.                      ;@@@@@@@@@#+,       ,+@@@@;.      .:#@@@@@@@@@#`                      .#@@@@@@@@@@,        ");
            Console.WriteLine("             :@@@@@@@@@@@;                     `@@@@@+.       :+@@@@@@@@@@@@'.      `:@@@@@,                      ;@@@@@@@@@@@:          ");
            Console.WriteLine("       `      `;@@@@@@@@@@@@`                    :@@@     :@@@@@@@@@@@@@@@@@@@@@#.    ;@@@                     `@@@@@@@@@@@@;`      `    ");
            Console.WriteLine("              `` :@@@@@@@@@@@@;                        @@@@@@@@@@#;`:@@':#@@@@@@@@@@@  @,                    ;@@@@@@@@@@@@; ``                              ");
            Console.WriteLine("       @#`         ;@@@@@@@@@@@@#.                    '@@@@@@@;.    :@@:   `,@@@@#@@@                     .#@@@@@@@@@@@@;         `#@    ");
            Console.WriteLine("       @@@@;          ;@@@@@@@@@@@@@;                  @@@@;`     :#@:@@@#;      ,@#@@+                  ;@@@@@@@@@@@@@;         ;@@@@            ");
            Console.WriteLine("      #@@@@@@@`     `  '@@@@@@@@@@@@@@.              ;@@@;   ,@@@@@@'@@@@@@@@;`  `#@@@               .@@@@@@@@@@@@@@'  `     `@@@@@@@#   ");
            Console.WriteLine("      ;@@@@@@@@@:       `'@@@@@@@@@@@@@@:            @@@@@#@@@@@@@@@@@@@@@@@@@@+.@@@@@;            :@@@@@@@@@@@@@@'`       ,@@@@@@@@@;   ");
            Console.WriteLine("         ;@@@@@@@#@+`       ;@#@@@@@@@@@@@@#.        ,@@@@@@@@@@@@@@@@'#@@@@@@@@;@@@@@@@         .#@@@@@@@@@@@@##'       `+@#@@@@@@@;     ");
            Console.WriteLine("          +@@@@@@@@@@;       #@@@@@@@@@@@@@@@;      @@@@@@@@@@@@@@+     :@@@@@@@@@@@@@@,      ;@@@@@@@@@@@@@@@#       :@@@@@@@@@@+       ");
            Console.WriteLine("            '@@@@@@@@@#@`      +@@@@@@@@@@@@@@@@   ` ;@@@@@@@@@+     `     ;@@@@@@@@@@;     @@@@@@@@@@@@@@@@+      `@@@@@@@@@@@'         ");
            Console.WriteLine("              '@@@@@@@@@@@:      +@@@@@@@@@@@@@@@@:    .#@@@+`    `+@@@#.    `:@@@@#.    :@@@@@@@@@@@@@@@@+      :@@@@@@@@@@@'           ");
            Console.WriteLine("                +@@@@@@@@@@@+`     #@@@@@@@@@@@@@@@@+`    .     '@@@@@@@@@+`    `:    `+@@@@@@@@@@@@@@@@#     `+@@@@@@@@@@@+             ");
            Console.WriteLine("       .  `       @@@@@@@@@@@@@;`    @@@@@@@@@@@@@@@@@@;  `  #@@@@@@@@@@@@@@@@`     ;@@@@@@@@@@@@@@@@@@  `` ;@@@@@@@@@@@@@          .    ");
            Console.WriteLine("       @@#`         +@@@@@@@@@@@@#    `+#@@@@@@@@@@@@@@@@@;@@@@@@@@@@@@@@@@@@@@@# @@@@@@@@@@@@@@@@@@+`   `#@@@@@@@@@@@@+          #@@    ");
            Console.WriteLine("      ,@@@@@,        `+@@@@@@@@@@@@#:  ``#@#@@@@@@@@@@@@@@@@@@@#@@@@@@@@@;@@#@@@@@@@@@@@@@@@@@@@#@#``  :#@@@@@@@@@@@#+`        ,#@@@@,   ");
            Console.WriteLine("      @@@@@@@@+         @@@@@@@@@@@@@@#    @@@@@@@@@@@@@@@@@@@@#` @@@@@@@  `#@@@@@@@@@@@@@@@@@@@@    #@@@@@@@@@@@@@@         +@@@@@@@@   ");
            Console.WriteLine("       #@@@@@@@@@,        #@@@@@@@@@@@@@@:   @@@@@@@@@@@@@@@@@ `@ @@@@@@@`+@` `+@@@@@@@@@@@@@@@   :@@@@@@@@@@@@@@#        ,@@@@@@@@@#    ");
            Console.WriteLine("        `#@@#@@@@@@+        #@@@@@@@@@@@@@@+` :@@@@@@@@@@+. @@ :  @@@@@@@  ``'+. .@@@@@@@@@@@. `'@@@@@@@@@@@@@@#        +@@@@@@#@@#`     ");
            Console.WriteLine("          `#@@@@@@@@@#,      `#@@@@@@@@@@@@@@@@@@@@@@@#. `+ @@`,  @@@@@@@  .`  `+ @@@@@@@@@@@@@@@@@@@@@@@@@@@#`      ,#@@@@@@@@@#`       ");
            Console.WriteLine("             @@@@@@@@@@@#       @@@@@@@@@@@@@@@@@@@@`  #@   @@ ,  @@@@@@@  ,``  ' @@@@ `@@@@@@@@@@@@@@@@@@@@       #@@@@@@@@@@@          ");
            Console.WriteLine("              `#@@@@@@@@@@@.     `#@@@@@@@@@@@@@@,  '+`     @# ,  @@@@@@@  , #@#  @@# ;'  .#@@@@@@@@@@@@@@`     .@@@@@@@@@@@@`           ");
            Console.WriteLine("                `##@@@@@@@@@@'`  ``#@@@@@@@@@#, @`@, ` ` ;@@@@ ,  @@@@@@@  , @@@#@@@ `  ,#:  ;@@@@@@@@@@+    `'@@@@@@@@@@##`             ");
            Console.WriteLine("                  `@@@@@@@@@@@@@;@@@@@@@@@@.  ; @`@  :  .@@@@@ ,  @@@@@@@  , @@@@@@@  :    `@ @@@@#@@@@@@@#:@@@@@@@@@@@@@`               ");
            Console.WriteLine("                    `@@@@@@@@@@@@@@@@@@@:  ;@. `@` ';:  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; ' ``..,@@. :@@@@@@@@@@@@@@@@@@@`                 ");
            Console.WriteLine("                      .#@@@@@@@@@@@@@'  ,@,     @#@@::  .@@@@@ ,  @@@@@@@  , @@@@@@@  : @@@  # @@.+, :@@@@@@@@@@@@@@#.                   ");
            Console.WriteLine("                       ,@@@@@@@@@@#@@,;,     ,#@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  . @@.  ;,@@':@@@@@@@@@@.                    ");
            Console.WriteLine("                    ,#@@@@@@@@@:   '#,'  `,  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  , @@,  ;,@@'   :@@@@@@@@@#.                 ");
            Console.WriteLine("                 `@@@@@@@@@@'  ,@:  @: .@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  . @@.  ;,@@';#.@@'@@@@@@@@@@`               ");
            Console.WriteLine("              .#@#@@@@@@@@  .@:     @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@    @@.  ;,@@'  #.@@  `;@@@@@@@@@#.           ");
            Console.WriteLine("           `+@@@@@@@@@@@@+`;     #  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@@@@@@@.  ;,@@'  #.@@ ,+ @@'@@@@@@@@@+         ");
            Console.WriteLine("         +@@@@@@@@@@`;@@@ @ ` `# +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  : @@@@@@@@@.  ;,@@'  #`@@  # @@   @@@@@@@@@`       ");
            Console.WriteLine("       ;@@@@@@@@+  `@ `@@ :  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@@@@@@@.  ;,@@'  #`@@  # @@ '@   +@@@@@@       ");
            Console.WriteLine("       ;@@@@@+` `+'`  `@@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  .    +@@@  ; :,,,;@@@@.  ;,@@'  #`@@  # @@  ``'+` `#@@@@      ");
            Console.WriteLine("       ;@@@`  '+`     `@@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@   .``.'@@@` :; ; ; ; ;``    @@.  :,@@'  #@@ # @@` ` +' #@@ ");
            Console.WriteLine("       ;@@@`@`    `.` `@@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@      `'@@@,       +: @@.  ::@@+  #`@@  # @@  .   ` `@ +@@@     ");
            Console.WriteLine("       ;@@@ ,  `'@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  ,`:,,'@@@@'       . @@.  ;````  #`@@  # @@  . @@;` `@ @@@     ");
            Console.WriteLine("       ;@@@ ,  @@@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  .`@@@@@@@@@@@@@@  . @@.         #`@@  # @@  . @@@#  @ @@@    ");
            Console.WriteLine("       ;@@@ ,  #@@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  . @@@@@@@@@@@@@@  . @@.  ,      #`@@  # @@  . @@@#  @ @@@    ");
            Console.WriteLine("       ;@@@ ,  @@#+` ` @@ ,  `.. +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@@@@@@@@  . @@.  ::@@+  #`@@  # @@  . @@@#  @ @@@    ");
            Console.WriteLine("       :@@@, ``  ,  ;@@ , ; ';'; +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@@@@@@@@  . @@.  ::@@'  #`@@  # @@  . @@@#   @@@@  ");
            Console.WriteLine("       ;@@@ , `````` #@@@ ,         @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@@@@@@@@  . @@.  ;,@@'  #`@@  # @@  . ####  @ @@@  ");
            Console.WriteLine("       ;@@@ ,         ,@# ,      #  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@@@@@@@@  . @@.  ;,@@'  #`@@  # @@  .`...`  @ @@@    ");
            Console.WriteLine("       ;@@@ ,  ###'.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@ `` @@@  . @@.  ;,@@'  #`@@  # @@   `     ;`+@@@    ");
            Console.WriteLine("       ;@@@ ,  @@@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  . @@.  ;,@@'  #`@@  # @@  `       @@@@@`   ");
            Console.WriteLine("       ;@@@ ,  @@@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  . @@.  ;,@@'  #`@@  # @@  . @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@ ,  @@@+.`  @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  @@@@@@@  , @@@@@@@  ; @@@  . @@.  ;,@@'  #`@@  # @@  . @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@ ,  +#+'`` `@@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,  +#+##@@  , ##++#@@  : #++ `. @@.  ;,@@'  #`@@  # @@  . @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@ ,  ````,   @@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ , ```` ,@@  .````` @@  ;````  . @@.  ;,@@'  #`@@  # @@  . @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@ , `       '@@ ,  @@@ +  @@@@@`.  @@@@@@@:,  .@@@@@ ,      ,@@       ; @@,       ` ,@@.  ;,@@'  #`@@  # @@  . @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@#@          @@@@    @@@ `  @@@@@    @@@@@@@:   .@@@@@        ,@@       ` #@@'      .'@@@,   ,@@'   `@@    @@    @@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@#@@@@@@@@@@@@@@#@@#@@#@@@@@@@@@@@@@@@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@`   ");
            Console.WriteLine("       ;@@@@@@@#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#@@#@@@@@@@@`   ");
            Console.WriteLine("       ;@@@@@`     #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@.   ``'@@@@@`   ");
            Console.WriteLine("       ;@@@@@@.     +@@@@@@@@#@#;+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@+;+@@@@@@@@@@@     `@@@@@@@    ");
            Console.WriteLine("       `:@@@@@+       @@@@@@@@' `    ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@'    .@@@@@@@#`      ;@@@@@@`         ");
            Console.WriteLine("                    `  @@@@@@@@@`      #@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@`      @@@@@@@@@.                  ");
            Console.WriteLine("                        @@@@@@@@        @@@@@@@@@@.     :@@@@@@@@@@@@@@@@@@@@@@@@@@@;     `#@@@@@@@@@`       #@@@@@@@:                   ");
            Console.WriteLine("                        `+@@@@#`        `@@@@@@##.+`     `.@@@@@@@@@@@@@@@@@@@@@@@;       #`@@@@@@@@;         +@@@@@`                    ");
            Console.WriteLine("                           ``            #@@@@@@@@@@        @@#@@@@@@@@@@@@@@@@@@        ;@@@@@@@@@#            ``                       ");
            Console.WriteLine("                                          #@@@@@@@#:       ` @@@@@@@@@@@@@@@@@@@         `@@@@@@@@@                                      ");
            Console.WriteLine("                                           +@@@@@#,`          @@@@@@@@@@@@@@@@@           `@@@@@@#                                       ");
            Console.WriteLine("                                             ,':.              ##@@@@@@@@@@@@@              `,':`                                        ");
            Console.WriteLine("                                                                @@@@@@@@@@@@@`                                                           ");
            Console.WriteLine("                                                                 @@@@@@@@@@@                                                             ");
            Console.WriteLine("                                                                  '@@@@@@@+                                                              ");
            Console.WriteLine("                                                                   `;@@@;                                                                ");
             Console.ReadLine();
            Console.Clear();
}

        public static void GetPlayerOneName()
        {


            Player p1 = new Player();
            Console.WriteLine("Welcome to Battleship!");
            Console.Write("Player One, enter your name...");
            p1.PlayerName = Console.ReadLine();
        }

        public static void GetPlayerTwoName()
        {
            Player p2 = new Player();
            Console.Write("Player Two, enter your name...");
            p2.PlayerName = Console.ReadLine();
        }

        public static void DrawSplashScreen()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"                 ___  ___ ______________   __________ ___________");
            Console.WriteLine(@"                / _ )/ _ /_  __/_  __/ /  / __/ __/ // /  _/ _  /");
            Console.WriteLine(@"               / _  / __ |/ /   / / / /__/ _/_\ \/ _  // // ___/");
            Console.WriteLine(@"              /____/_/ |_/_/   /_/ /____/___/___/_//_/___/_/");    
            Console.WriteLine(@"              - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine(@"               - - - - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("\n\n\n");
                                                 
        }

    }
}
