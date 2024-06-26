﻿namespace AOR_Extended_WPF.Utils
{
    public static class EventCodes
    {
        public const int Leave = 1;
        public const int JoinFinished = 2;
        public const int Move = 3;
        public const int Teleport = 4;
        public const int ChangeEquipment = 5;
        public const int HealthUpdate = 6;
        public const int EnergyUpdate = 7;
        public const int DamageShieldUpdate = 8;
        public const int CraftingFocusUpdate = 9;
        public const int ActiveSpellEffectsUpdate = 10;
        public const int ResetCooldowns = 11;
        public const int Attack = 12;
        public const int CastStart = 13;
        public const int ChannelingUpdate = 14;
        public const int CastCancel = 15;
        public const int CastTimeUpdate = 16;
        public const int CastFinished = 17;
        public const int CastSpell = 18;
        public const int CastSpells = 19;
        public const int CastHit = 20;
        public const int CastHits = 21;
        public const int StoredTargetsUpdate = 22;
        public const int ChannelingEnded = 23;
        public const int AttackBuilding = 24;
        public const int InventoryPutItem = 25;
        public const int InventoryDeleteItem = 26;
        public const int InventoryState = 27;
        public const int NewCharacter = 28;
        public const int NewEquipmentItem = 29;
        public const int NewSiegeBannerItem = 30;
        public const int NewSimpleItem = 31;
        public const int NewFurnitureItem = 32;
        public const int NewKillTrophyItem = 33;
        public const int NewJournalItem = 34;
        public const int NewLaborerItem = 35;
        public const int NewEquipmentItemLegendarySoul = 36;
        public const int NewSimpleHarvestableObject = 37;
        public const int NewSimpleHarvestableObjectList = 38;
        public const int NewHarvestableObject = 39;
        public const int NewTreasureDestinationObject = 40;
        public const int TreasureDestinationObjectStatus = 41;
        public const int CloseTreasureDestinationObject = 42;
        public const int NewSilverObject = 43;
        public const int NewBuilding = 44;
        public const int HarvestableChangeState = 45;
        public const int MobChangeState = 46;
        public const int FactionBuildingInfo = 47;
        public const int CraftBuildingInfo = 48;
        public const int RepairBuildingInfo = 49;
        public const int MeldBuildingInfo = 50;
        public const int ConstructionSiteInfo = 51;
        public const int PlayerBuildingInfo = 52;
        public const int FarmBuildingInfo = 53;
        public const int TutorialBuildingInfo = 54;
        public const int LaborerObjectInfo = 55;
        public const int LaborerObjectJobInfo = 56;
        public const int MarketPlaceBuildingInfo = 57;
        public const int HarvestStart = 58;
        public const int HarvestCancel = 59;
        public const int HarvestFinished = 60;
        public const int TakeSilver = 61;
        public const int ActionOnBuildingStart = 62;
        public const int ActionOnBuildingCancel = 63;
        public const int ActionOnBuildingFinished = 64;
        public const int ItemRerollQualityFinished = 65;
        public const int InstallResourceStart = 66;
        public const int InstallResourceCancel = 67;
        public const int InstallResourceFinished = 68;
        public const int CraftItemFinished = 69;
        public const int LogoutCancel = 70;
        public const int ChatMessage = 71;
        public const int ChatSay = 72;
        public const int ChatWhisper = 73;
        public const int ChatMuted = 74;
        public const int PlayEmote = 75;
        public const int StopEmote = 76;
        public const int SystemMessage = 77;
        public const int UtilityTextMessage = 78;
        public const int UpdateMoney = 79;
        public const int UpdateFame = 80;
        public const int UpdateLearningPoints = 81;
        public const int UpdateReSpecPoints = 82;
        public const int UpdateCurrency = 83;
        public const int UpdateFactionStanding = 84;
        public const int UpdateMistCityStanding = 85;
        public const int Respawn = 86;
        public const int ServerDebugLog = 87;
        public const int CharacterEquipmentChanged = 88;
        public const int RegenerationHealthChanged = 89;
        public const int RegenerationEnergyChanged = 90;
        public const int RegenerationMountHealthChanged = 91;
        public const int RegenerationCraftingChanged = 92;
        public const int RegenerationHealthEnergyComboChanged = 93;
        public const int RegenerationPlayerComboChanged = 94;
        public const int DurabilityChanged = 95;
        public const int NewLoot = 96;
        public const int AttachItemContainer = 97;
        public const int DetachItemContainer = 98;
        public const int InvalidateItemContainer = 99;
        public const int LockItemContainer = 100;
        public const int GuildUpdate = 101;
        public const int GuildPlayerUpdated = 102;
        public const int InvitedToGuild = 103;
        public const int GuildMemberWorldUpdate = 104;
        public const int UpdateMatchDetails = 105;
        public const int ObjectEvent = 106;
        public const int NewMonolithObject = 107;
        public const int MonolithHasBannersPlacedUpdate = 108;
        public const int NewOrbObject = 109;
        public const int NewCastleObject = 110;
        public const int NewSpellEffectArea = 111;
        public const int UpdateSpellEffectArea = 112;
        public const int NewChainSpell = 113;
        public const int UpdateChainSpell = 114;
        public const int NewTreasureChest = 115;
        public const int StartMatch = 116;
        public const int StartArenaMatchInfos = 117;
        public const int EndArenaMatch = 118;
        public const int MatchUpdate = 119;
        public const int ActiveMatchUpdate = 120;
        public const int NewMob = 121;
        public const int DebugMobInfo = 122;
        public const int DebugVariablesInfo = 123;
        public const int DebugReputationInfo = 124;
        public const int DebugDiminishingReturnInfo = 125;
        public const int DebugSmartClusterQueueInfo = 126;
        public const int ClaimOrbStart = 127;
        public const int ClaimOrbFinished = 128;
        public const int ClaimOrbCancel = 129;
        public const int OrbUpdate = 130;
        public const int OrbClaimed = 131;
        public const int OrbReset = 132;
        public const int NewWarCampObject = 133;
        public const int NewMatchLootChestObject = 134;
        public const int NewArenaExit = 135;
        public const int GuildMemberTerritoryUpdate = 136;
        public const int InvitedMercenaryToMatch = 137;
        public const int ClusterInfoUpdate = 138;
        public const int ForcedMovement = 139;
        public const int ForcedMovementCancel = 140;
        public const int CharacterStats = 141;
        public const int CharacterStatsKillHistory = 142;
        public const int CharacterStatsDeathHistory = 143;
        public const int GuildStats = 144;
        public const int KillHistoryDetails = 145;
        public const int FullAchievementInfo = 146;
        public const int FinishedAchievement = 147;
        public const int AchievementProgressInfo = 148;
        public const int FullAchievementProgressInfo = 149;
        public const int FullTrackedAchievementInfo = 150;
        public const int FullAutoLearnAchievementInfo = 151;
        public const int QuestGiverQuestOffered = 152;
        public const int QuestGiverDebugInfo = 153;
        public const int ConsoleEvent = 154;
        public const int TimeSync = 155;
        public const int ChangeAvatar = 156;
        public const int ChangeMountSkin = 157;
        public const int GameEvent = 158;
        public const int KilledPlayer = 159;
        public const int Died = 160;
        public const int KnockedDown = 161;
        public const int Unconcious = 162;
        public const int MatchPlayerJoinedEvent = 163;
        public const int MatchPlayerStatsEvent = 164;
        public const int MatchPlayerStatsCompleteEvent = 165;
        public const int MatchTimeLineEventEvent = 166;
        public const int MatchPlayerMainGearStatsEvent = 167;
        public const int MatchPlayerChangedAvatarEvent = 168;
        public const int InvitationPlayerTrade = 169;
        public const int PlayerTradeStart = 170;
        public const int PlayerTradeCancel = 171;
        public const int PlayerTradeUpdate = 172;
        public const int PlayerTradeFinished = 173;
        public const int PlayerTradeAcceptChange = 174;
        public const int MiniMapPing = 175;
        public const int MarketPlaceNotification = 176;
        public const int DuellingChallengePlayer = 177;
        public const int NewDuellingPost = 178;
        public const int DuelStarted = 179;
        public const int DuelEnded = 180;
        public const int DuelDenied = 181;
        public const int DuelRequestCanceled = 182;
        public const int DuelLeftArea = 183;
        public const int DuelReEnteredArea = 184;
        public const int NewRealEstate = 185;
        public const int MiniMapOwnedBuildingsPositions = 186;
        public const int RealEstateListUpdate = 187;
        public const int GuildLogoUpdate = 188;
        public const int GuildLogoChanged = 189;
        public const int PlaceableObjectPlace = 190;
        public const int PlaceableObjectPlaceCancel = 191;
        public const int FurnitureObjectBuffProviderInfo = 192;
        public const int FurnitureObjectCheatProviderInfo = 193;
        public const int FarmableObjectInfo = 194;
        public const int NewUnreadMails = 195;
        public const int MailOperationPossible = 196;
        public const int GuildLogoObjectUpdate = 197;
        public const int StartLogout = 198;
        public const int NewChatChannels = 199;
        public const int JoinedChatChannel = 200;
        public const int LeftChatChannel = 201;
        public const int RemovedChatChannel = 202;
        public const int AccessStatus = 203;
        public const int Mounted = 204;
        public const int MountStart = 205;
        public const int MountCancel = 206;
        public const int NewTravelpoint = 207;
        public const int NewIslandAccessPoint = 208;
        public const int NewExit = 209;
        public const int UpdateHome = 210;
        public const int UpdateChatSettings = 211;
        public const int ResurrectionOffer = 212;
        public const int ResurrectionReply = 213;
        public const int LootEquipmentChanged = 214;
        public const int UpdateUnlockedGuildLogos = 215;
        public const int UpdateUnlockedAvatars = 216;
        public const int UpdateUnlockedAvatarRings = 217;
        public const int UpdateUnlockedBuildings = 218;
        public const int NewIslandManagement = 219;
        public const int NewTeleportStone = 220;
        public const int Cloak = 221;
        public const int PartyInvitation = 222;
        public const int PartyJoinRequest = 223;
        public const int PartyJoined = 224;
        public const int PartyDisbanded = 225;
        public const int PartyPlayerJoined = 226;
        public const int PartyChangedOrder = 227;
        public const int PartyPlayerLeft = 228;
        public const int PartyLeaderChanged = 229;
        public const int PartyLootSettingChangedPlayer = 230;
        public const int PartySilverGained = 231;
        public const int PartyPlayerUpdated = 232;
        public const int PartyInvitationAnswer = 233;
        public const int PartyJoinRequestAnswer = 234;
        public const int PartyMarkedObjectsUpdated = 235;
        public const int PartyOnClusterPartyJoined = 236;
        public const int PartySetRoleFlag = 237;
        public const int PartyInviteOrJoinPlayerEquipmentInfo = 238;
        public const int SpellCooldownUpdate = 239;
        public const int NewHellgateExitPortal = 240;
        public const int NewExpeditionExit = 241;
        public const int NewExpeditionNarrator = 242;
        public const int ExitEnterStart = 243;
        public const int ExitEnterCancel = 244;
        public const int ExitEnterFinished = 245;
        public const int NewQuestGiverObject = 246;
        public const int FullQuestInfo = 247;
        public const int QuestProgressInfo = 248;
        public const int QuestGiverInfoForPlayer = 249;
        public const int FullExpeditionInfo = 250;
        public const int ExpeditionQuestProgressInfo = 251;
        public const int InvitedToExpedition = 252;
        public const int ExpeditionRegistrationInfo = 253;
        public const int EnteringExpeditionStart = 254;
        public const int EnteringExpeditionCancel = 255;
        public const int RewardGranted = 256;
        public const int ArenaRegistrationInfo = 257;
        public const int EnteringArenaStart = 258;
        public const int EnteringArenaCancel = 259;
        public const int EnteringArenaLockStart = 260;
        public const int EnteringArenaLockCancel = 261;
        public const int InvitedToArenaMatch = 262;
        public const int UsingHellgateShrine = 263;
        public const int EnteringHellgateLockStart = 264;
        public const int EnteringHellgateLockCancel = 265;
        public const int PlayerCounts = 266;
        public const int InCombatStateUpdate = 267;
        public const int OtherGrabbedLoot = 268;
        public const int TreasureChestUsingStart = 269;
        public const int TreasureChestUsingFinished = 270;
        public const int TreasureChestUsingCancel = 271;
        public const int TreasureChestUsingOpeningComplete = 272;
        public const int TreasureChestForceCloseInventory = 273;
        public const int LocalTreasuresUpdate = 274;
        public const int LootChestSpawnpointsUpdate = 275;
        public const int PremiumChanged = 276;
        public const int PremiumExtended = 277;
        public const int PremiumLifeTimeRewardGained = 278;
        public const int GoldPurchased = 279;
        public const int LaborerGotUpgraded = 280;
        public const int JournalGotFull = 281;
        public const int JournalFillError = 282;
        public const int FriendRequest = 283;
        public const int FriendRequestInfos = 284;
        public const int FriendInfos = 285;
        public const int FriendRequestAnswered = 286;
        public const int FriendOnlineStatus = 287;
        public const int FriendRequestCanceled = 288;
        public const int FriendRemoved = 289;
        public const int FriendUpdated = 290;
        public const int PartyLootItems = 291;
        public const int PartyLootItemsRemoved = 292;
        public const int ReputationUpdate = 293;
        public const int DefenseUnitAttackBegin = 294;
        public const int DefenseUnitAttackEnd = 295;
        public const int DefenseUnitAttackDamage = 296;
        public const int UnrestrictedPvpZoneUpdate = 297;
        public const int ReputationImplicationUpdate = 298;
        public const int NewMountObject = 299;
        public const int MountHealthUpdate = 300;
        public const int MountCooldownUpdate = 301;
        public const int NewExpeditionAgent = 302;
        public const int NewExpeditionCheckPoint = 303;
        public const int ExpeditionStartEvent = 304;
        public const int VoteEvent = 305;
        public const int RatingEvent = 306;
        public const int NewArenaAgent = 307;
        public const int BoostFarmable = 308;
        public const int UseFunction = 309;
        public const int NewPortalEntrance = 310;
        public const int NewPortalExit = 311;
        public const int NewRandomDungeonExit = 312;
        public const int WaitingQueueUpdate = 313;
        public const int PlayerMovementRateUpdate = 314;
        public const int ObserveStart = 315;
        public const int MinimapZergs = 316;
        public const int MinimapSmartClusterZergs = 317;
        public const int PaymentTransactions = 318;
        public const int PerformanceStatsUpdate = 319;
        public const int OverloadModeUpdate = 320;
        public const int DebugDrawEvent = 321;
        public const int RecordCameraMove = 322;
        public const int RecordStart = 323;
        public const int DeliverCarriableObjectStart = 324;
        public const int DeliverCarriableObjectCancel = 325;
        public const int DeliverCarriableObjectReset = 326;
        public const int DeliverCarriableObjectFinished = 327;
        public const int TerritoryClaimStart = 328;
        public const int TerritoryClaimCancel = 329;
        public const int TerritoryClaimFinished = 330;
        public const int TerritoryScheduleResult = 331;
        public const int TerritoryUpgradeWithPowerCrystalResult = 332;
        public const int ReceiveCarriableObjectStart = 333;
        public const int ReceiveCarriableObjectFinished = 334;
        public const int UpdateAccountState = 335;
        public const int StartDeterministicRoam = 336;
        public const int GuildFullAccessTagsUpdated = 337;
        public const int GuildAccessTagUpdated = 338;
        public const int GvgSeasonUpdate = 339;
        public const int GvgSeasonCheatCommand = 340;
        public const int SeasonPointsByKillingBooster = 341;
        public const int FishingStart = 342;
        public const int FishingCast = 343;
        public const int FishingCatch = 344;
        public const int FishingFinished = 345;
        public const int FishingCancel = 346;
        public const int NewFloatObject = 347;
        public const int NewFishingZoneObject = 348;
        public const int FishingMiniGame = 349;
        public const int AlbionJournalAchievementCompleted = 350;
        public const int UpdatePuppet = 351;
        public const int ChangeFlaggingFinished = 352;
        public const int NewOutpostObject = 353;
        public const int OutpostUpdate = 354;
        public const int OutpostClaimed = 355;
        public const int OverChargeEnd = 356;
        public const int OverChargeStatus = 357;
        public const int PartyFinderFullUpdate = 358;
        public const int PartyFinderUpdate = 359;
        public const int PartyFinderApplicantsUpdate = 360;
        public const int PartyFinderEquipmentSnapshot = 361;
        public const int PartyFinderJoinRequestDeclined = 362;
        public const int NewUnlockedPersonalSeasonRewards = 363;
        public const int PersonalSeasonPointsGained = 364;
        public const int PersonalSeasonPastSeasonDataEvent = 365;
        public const int EasyAntiCheatMessageToClient = 366;
        public const int MatchLootChestOpeningStart = 367;
        public const int MatchLootChestOpeningFinished = 368;
        public const int MatchLootChestOpeningCancel = 369;
        public const int NotifyCrystalMatchReward = 370;
        public const int CrystalRealmFeedback = 371;
        public const int NewLocationMarker = 372;
        public const int NewTutorialBlocker = 373;
        public const int NewTileSwitch = 374;
        public const int NewInformationProvider = 375;
        public const int NewDynamicGuildLogo = 376;
        public const int NewDecoration = 377;
        public const int TutorialUpdate = 378;
        public const int TriggerHintBox = 379;
        public const int RandomDungeonPositionInfo = 380;
        public const int NewLootChest = 381;
        public const int UpdateLootChest = 382;
        public const int LootChestOpened = 383;
        public const int UpdateLootProtectedByMobsWithMinimapDisplay = 384;
        public const int NewShrine = 385;
        public const int UpdateShrine = 386;
        public const int UpdateRoom = 387;
        public const int NewMistDungeonRoomMobSoul = 388;
        public const int NewHellgateShrine = 389;
        public const int UpdateHellgateShrine = 390;
        public const int ActivateHellgateExit = 391;
        public const int MutePlayerUpdate = 392;
        public const int ShopTileUpdate = 393;
        public const int ShopUpdate = 394;
        public const int AntiCheatKick = 395;
        public const int BattlEyeServerMessage = 396;
        public const int UnlockVanityUnlock = 397;
        public const int AvatarUnlocked = 398;
        public const int CustomizationChanged = 399;
        public const int BaseVaultInfo = 400;
        public const int GuildVaultInfo = 401;
        public const int BankVaultInfo = 402;
        public const int RecoveryVaultPlayerInfo = 403;
        public const int RecoveryVaultGuildInfo = 404;
        public const int UpdateWardrobe = 405;
        public const int CastlePhaseChanged = 406;
        public const int GuildAccountLogEvent = 407;
        public const int NewHideoutObject = 408;
        public const int NewHideoutManagement = 409;
        public const int NewHideoutExit = 410;
        public const int InitHideoutAttackStart = 411;
        public const int InitHideoutAttackCancel = 412;
        public const int InitHideoutAttackFinished = 413;
        public const int HideoutManagementUpdate = 414;
        public const int HideoutUpgradeWithPowerCrystalResult = 415;
        public const int IpChanged = 416;
        public const int SmartClusterQueueUpdateInfo = 417;
        public const int SmartClusterQueueActiveInfo = 418;
        public const int SmartClusterQueueKickWarning = 419;
        public const int SmartClusterQueueInvite = 420;
        public const int ReceivedGvgSeasonPoints = 421;
        public const int TowerPowerPointUpdate = 422;
        public const int OpenWorldAttackScheduleStart = 423;
        public const int OpenWorldAttackScheduleFinished = 424;
        public const int OpenWorldAttackScheduleCancel = 425;
        public const int OpenWorldAttackConquerStart = 426;
        public const int OpenWorldAttackConquerFinished = 427;
        public const int OpenWorldAttackConquerCancel = 428;
        public const int OpenWorldAttackConquerStatus = 429;
        public const int OpenWorldAttackStart = 430;
        public const int OpenWorldAttackEnd = 431;
        public const int NewRandomResourceBlocker = 432;
        public const int NewHomeObject = 433;
        public const int HideoutObjectUpdate = 434;
        public const int UpdateInfamy = 435;
        public const int MinimapPositionMarkers = 436;
        public const int NewTunnelExit = 437;
        public const int CorruptedDungeonUpdate = 438;
        public const int CorruptedDungeonStatus = 439;
        public const int CorruptedDungeonInfamy = 440;
        public const int HellgateRestrictedAreaUpdate = 441;
        public const int HellgateInfamy = 442;
        public const int HellgateStatus = 443;
        public const int HellgateStatusUpdate = 444;
        public const int HellgateSuspense = 445;
        public const int ReplaceSpellSlotWithMultiSpell = 446;
        public const int NewCorruptedShrine = 447;
        public const int UpdateCorruptedShrine = 448;
        public const int CorruptedShrineUsageStart = 449;
        public const int CorruptedShrineUsageCancel = 450;
        public const int ExitUsed = 451;
        public const int LinkedToObject = 452;
        public const int LinkToObjectBroken = 453;
        public const int EstimatedMarketValueUpdate = 454;
        public const int StuckCancel = 455;
        public const int DungonEscapeReady = 456;
        public const int FactionWarfareClusterState = 457;
        public const int FactionWarfareHasUnclaimedWeeklyReportsEvent = 458;
        public const int SimpleFeedback = 459;
        public const int SmartClusterQueueSkipClusterError = 460;
        public const int XignCodeEvent = 461;
        public const int BatchUseItemStart = 462;
        public const int BatchUseItemEnd = 463;
        public const int RedZoneEventClusterStatus = 464;
        public const int RedZonePlayerNotification = 465;
        public const int RedZoneWorldEvent = 466;
        public const int FactionWarfareStats = 467;
        public const int UpdateFactionBalanceFactors = 468;
        public const int FactionEnlistmentChanged = 469;
        public const int UpdateFactionRank = 470;
        public const int FactionWarfareCampaignRewardsUnlocked = 471;
        public const int FeaturedFeatureUpdate = 472;
        public const int NewCarriableObject = 473;
        public const int MinimapCrystalPositionMarker = 474;
        public const int CarriedObjectUpdate = 475;
        public const int PickupCarriableObjectStart = 476;
        public const int PickupCarriableObjectCancel = 477;
        public const int PickupCarriableObjectFinished = 478;
        public const int DoSimpleActionStart = 479;
        public const int DoSimpleActionCancel = 480;
        public const int DoSimpleActionFinished = 481;
        public const int NotifyGuestAccountVerified = 482;
        public const int MightAndFavorReceivedEvent = 483;
        public const int WeeklyPvpChallengeRewardStateUpdate = 484;
        public const int NewUnlockedPvpSeasonChallengeRewards = 485;
        public const int StaticDungeonEntrancesDungeonEventStatusUpdates = 486;
        public const int StaticDungeonDungeonValueUpdate = 487;
        public const int StaticDungeonEntranceDungeonEventsAborted = 488;
        public const int InAppPurchaseConfirmedGooglePlay = 489;
        public const int FeatureSwitchInfo = 490;
        public const int PartyJoinRequestAborted = 491;
        public const int PartyInviteAborted = 492;
        public const int PartyStartHuntRequest = 493;
        public const int PartyStartHuntRequested = 494;
        public const int PartyStartHuntRequestAnswer = 495;
        public const int GuildInviteDeclined = 496;
        public const int CancelMultiSpellSlots = 497;
        public const int NewVisualEventObject = 498;
        public const int CastleClaimProgress = 499;
        public const int CastleClaimProgressLogo = 500;
        public const int TownPortalUpdateState = 501;
        public const int TownPortalFailed = 502;
        public const int ConsumableVanityChargesAdded = 503;
        public const int FestivitiesUpdate = 504;
        public const int NewBannerObject = 505;
        public const int NewMistsImmediateReturnExit = 506;
        public const int MistsPlayerJoinedInfo = 507;
        public const int NewMistsStaticEntrance = 508;
        public const int NewMistsOpenWorldExit = 509;
        public const int NewTunnelExitTemp = 510;
        public const int NewMistsWispSpawn = 511;
        public const int MistsWispSpawnStateChange = 512;
        public const int NewMistsCityEntrance = 513;
        public const int NewMistsCityRoadsEntrance = 514;
        public const int MistsCityRoadsEntrancePartyStateUpdate = 515;
        public const int MistsCityRoadsEntranceClearStateForParty = 516;
        public const int MistsEntranceDataChanged = 517;
        public const int NewMistsCagedWisp = 518;
        public const int MistsWispCageOpened = 519;
        public const int MistsEntrancePartyBindingCreated = 520;
        public const int MistsEntrancePartyBindingCleared = 521;
        public const int MistsEntrancePartyBindingInfos = 522;
        public const int NewMistsBorderExit = 523;
        public const int NewMistsDungeonExit = 524;
        public const int LocalQuestInfos = 525;
        public const int LocalQuestStarted = 526;
        public const int LocalQuestActive = 527;
        public const int LocalQuestInactive = 528;
        public const int LocalQuestProgressUpdate = 529;
        public const int NewUnrestrictedPvpZone = 530;
        public const int TemporaryFlaggingStatusUpdate = 531;
        public const int SpellTestPerformanceUpdate = 532;
        public const int Transformation = 533;
        public const int TransformationEnd = 534;
        public const int UpdateTrustlevel = 535;
        public const int RevealHiddenTimeStamps = 536;
        public const int ModifyItemTraitFinished = 537;
        public const int RerollItemTraitValueFinished = 538;
        public const int HuntQuestProgressInfo = 539;
        public const int HuntStarted = 540;
        public const int HuntFinished = 541;
        public const int HuntAborted = 542;
        public const int HuntMissionStepStateUpdate = 543;
        public const int NewHuntTrack = 544;
        public const int HuntMissionUpdate = 545;
        public const int HuntQuestMissionProgressUpdate = 546;
        public const int HuntTrackUsed = 547;
        public const int HuntTrackUseableAgain = 548;
        public const int MinimapHuntTrackMarkers = 549;
        public const int NoTracksFound = 550;
        public const int HuntQuestAborted = 551;
        public const int InteractWithTrackStart = 552;
        public const int InteractWithTrackCancel = 553;
        public const int InteractWithTrackFinished = 554;
        public const int NewDynamicCompound = 555;
        public const int LegendaryItemDestroyed = 556;
        public const int AttunementInfo = 557;
        public const int TerritoryClaimRaidedRawEnergyCrystalResult = 558;
        public const int CarriedObjectExpiryWarning = 559;
        public const int CarriedObjectExpired = 560;
        public const int TerritoryRaidStart = 561;
        public const int TerritoryRaidCancel = 562;
        public const int TerritoryRaidFinished = 563;
        public const int TerritoryRaidResult = 564;
        public const int TerritoryMonolithActiveRaidStatus = 565;
        public const int TerritoryMonolithActiveRaidCancelled = 566;
        public const int MonolithEnergyStorageUpdate = 567;
        public const int MonolithNextScheduledOpenWorldAttackUpdate = 568;
        public const int MonolithProtectedBuildingsDamageReductionUpdate = 569;
        public const int NewBuildingBaseEvent = 570;
        public const int NewFortificationBuilding = 571;
        public const int NewCastleGateBuilding = 572;
        public const int BuildingDurabilityUpdate = 573;
        public const int MonolithFortificationPointsUpdate = 574;
        public const int FortificationBuildingUpgradeInfo = 575;
        public const int FortificationBuildingsDamageStateUpdate = 576;
        public const int SiegeNotificationEvent = 577;
        public const int UpdateEnemyWarBannerActive = 578;
        public const int TerritoryAnnouncePlayerEjection = 579;
        public const int CastleGateSwitchUseStarted = 580;
        public const int CastleGateSwitchUseFinished = 581;
        public const int FortificationBuildingWillDowngrade = 582;
        public const int BotCommand = 583;
    }
}
