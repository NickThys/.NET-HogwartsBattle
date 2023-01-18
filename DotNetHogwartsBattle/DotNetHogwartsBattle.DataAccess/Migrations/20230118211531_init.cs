using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetHogwartsBattle.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deck<GameDiscardable>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck<GameDiscardable>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck<Location>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck<Location>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck<StartHero>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck<StartHero>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deck<Villain>",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackImg = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deck<Villain>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trigger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    When = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trigger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriggerEvent",
                columns: table => new
                {
                    TriggerId = table.Column<int>(type: "int", nullable: false),
                    Event = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerEvent", x => new { x.TriggerId, x.Event });
                    table.ForeignKey(
                        name: "FK_TriggerEvent_Trigger_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Trigger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TriggerTriggeredBy",
                columns: table => new
                {
                    TriggerId = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerTriggeredBy", x => new { x.TriggerId, x.CardType });
                    table.ForeignKey(
                        name: "FK_TriggerTriggeredBy_Trigger_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Trigger",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HasToChooseBetween = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartHeroId = table.Column<int>(type: "int", nullable: true),
                    TriggerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ability_Trigger_TriggerId",
                        column: x => x.TriggerId,
                        principalTable: "Trigger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Action",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Target = table.Column<int>(type: "int", nullable: false),
                    NrOfActions = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    AbilityId = table.Column<int>(type: "int", nullable: true),
                    RewardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Action", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Action_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Action_Reward_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Reward",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardKind = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameIdentifier = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeckGameDiscardableId = table.Column<int>(name: "Deck<GameDiscardable>Id", type: "int", nullable: true),
                    LocationNr = table.Column<int>(type: "int", nullable: true),
                    NrOfLocations = table.Column<int>(type: "int", nullable: true),
                    NrOfDarkArtsReveals = table.Column<int>(type: "int", nullable: true),
                    NrOfDarkMarkTokens = table.Column<int>(type: "int", nullable: true),
                    NrOfDarkMarkTokensNeeded = table.Column<int>(type: "int", nullable: true),
                    DeckLocationId = table.Column<int>(name: "Deck<Location>Id", type: "int", nullable: true),
                    Villain_AbilityId = table.Column<int>(type: "int", nullable: true),
                    Health = table.Column<int>(type: "int", nullable: true),
                    RewardId = table.Column<int>(type: "int", nullable: true),
                    DeckVillainId = table.Column<int>(name: "Deck<Villain>Id", type: "int", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true),
                    AbilityId = table.Column<int>(type: "int", nullable: true),
                    Hero_AbilityId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: true),
                    DeckStartHeroId = table.Column<int>(name: "Deck<StartHero>Id", type: "int", nullable: true),
                    PlayerBoardId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cards_Ability_Hero_AbilityId",
                        column: x => x.Hero_AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cards_Ability_Villain_AbilityId",
                        column: x => x.Villain_AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Cards_Deck<GameDiscardable>_Deck<GameDiscardable>Id",
                        column: x => x.DeckGameDiscardableId,
                        principalTable: "Deck<GameDiscardable>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Deck<Location>_Deck<Location>Id",
                        column: x => x.DeckLocationId,
                        principalTable: "Deck<Location>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Deck<StartHero>_Deck<StartHero>Id",
                        column: x => x.DeckStartHeroId,
                        principalTable: "Deck<StartHero>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Deck<Villain>_Deck<Villain>Id",
                        column: x => x.DeckVillainId,
                        principalTable: "Deck<Villain>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cards_Reward_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Reward",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentGameIdentifier = table.Column<int>(type: "int", nullable: false),
                    VillainsDeckId = table.Column<int>(type: "int", nullable: false),
                    LocationDeckId = table.Column<int>(type: "int", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    DiscardDeckId = table.Column<int>(type: "int", nullable: false),
                    NrOfVillainsActive = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Cards_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Cards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Deck<GameDiscardable>_DiscardDeckId",
                        column: x => x.DiscardDeckId,
                        principalTable: "Deck<GameDiscardable>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Deck<Location>_LocationDeckId",
                        column: x => x.LocationDeckId,
                        principalTable: "Deck<Location>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Games_Deck<Villain>_VillainsDeckId",
                        column: x => x.VillainsDeckId,
                        principalTable: "Deck<Villain>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActivePlayer = table.Column<bool>(type: "bit", nullable: false),
                    PlayerOrder = table.Column<int>(type: "int", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    NrOfAttacks = table.Column<int>(type: "int", nullable: false),
                    NrOfInfluenceTokens = table.Column<int>(type: "int", nullable: false),
                    DrawDeckId = table.Column<int>(type: "int", nullable: false),
                    DiscardDeckId = table.Column<int>(type: "int", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerBoards_Deck<StartHero>_DiscardDeckId",
                        column: x => x.DiscardDeckId,
                        principalTable: "Deck<StartHero>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerBoards_Deck<StartHero>_DrawDeckId",
                        column: x => x.DrawDeckId,
                        principalTable: "Deck<StartHero>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PlayerBoards_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_StartHeroId",
                table: "Ability",
                column: "StartHeroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_TriggerId",
                table: "Ability",
                column: "TriggerId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_AbilityId",
                table: "Action",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Action_RewardId",
                table: "Action",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_AbilityId",
                table: "Cards",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Deck<GameDiscardable>Id",
                table: "Cards",
                column: "Deck<GameDiscardable>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Deck<Location>Id",
                table: "Cards",
                column: "Deck<Location>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Deck<StartHero>Id",
                table: "Cards",
                column: "Deck<StartHero>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Deck<Villain>Id",
                table: "Cards",
                column: "Deck<Villain>Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_GameId",
                table: "Cards",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Hero_AbilityId",
                table: "Cards",
                column: "Hero_AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PlayerBoardId",
                table: "Cards",
                column: "PlayerBoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_RewardId",
                table: "Cards",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_Villain_AbilityId",
                table: "Cards",
                column: "Villain_AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_DiscardDeckId",
                table: "Games",
                column: "DiscardDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LocationDeckId",
                table: "Games",
                column: "LocationDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_LocationId",
                table: "Games",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_VillainsDeckId",
                table: "Games",
                column: "VillainsDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBoards_DiscardDeckId",
                table: "PlayerBoards",
                column: "DiscardDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBoards_DrawDeckId",
                table: "PlayerBoards",
                column: "DrawDeckId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerBoards_GameId",
                table: "PlayerBoards",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ability_Cards_StartHeroId",
                table: "Ability",
                column: "StartHeroId",
                principalTable: "Cards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Games_GameId",
                table: "Cards",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PlayerBoards_PlayerBoardId",
                table: "Cards",
                column: "PlayerBoardId",
                principalTable: "PlayerBoards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ability_Cards_StartHeroId",
                table: "Ability");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Cards_LocationId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Action");

            migrationBuilder.DropTable(
                name: "TriggerEvent");

            migrationBuilder.DropTable(
                name: "TriggerTriggeredBy");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "PlayerBoards");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "Trigger");

            migrationBuilder.DropTable(
                name: "Deck<StartHero>");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Deck<GameDiscardable>");

            migrationBuilder.DropTable(
                name: "Deck<Location>");

            migrationBuilder.DropTable(
                name: "Deck<Villain>");
        }
    }
}
