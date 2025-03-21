using GorillaCraft.Behaviours;
using GorillaCraft.Blocks.Nonsolid;
using GorillaCraft.Blocks.Solid;
using GorillaCraft.Interfaces;
using GorillaCraft.Tools;
using GorillaLocomotion;
using System;
using UnityEngine;
using Zenject;

namespace GorillaCraft.Models
{
    public class MainInstaller : Installer
    {
        public GameObject Player => UnityEngine.Object.FindObjectOfType<GTPlayer>().gameObject;

        public override void InstallBindings()
        {
            Container.BindFactory<Type, IDataType, BlockDataFactory_PL>().FromFactory<BlockDataFactory>();

            Container.BindInterfacesAndSelfTo<Main>().FromNewComponentOn(Player).AsSingle();
            Container.BindInterfacesAndSelfTo<Logging>().AsSingle();
            Container.BindInterfacesAndSelfTo<Configuration>().AsSingle();

            Container.Bind<BlockHandler>().FromNewComponentOn(Player).AsSingle();
            Container.Bind<PlacementHelper>().FromNewComponentOn(Player).AsSingle();

            Container.Bind<AssetLoader>().AsSingle();

            Container.Bind<IBlock>().To<GrassBlock>().AsSingle();
            Container.Bind<IBlock>().To<PodzolBlock>().AsSingle();
            Container.Bind<IBlock>().To<SnowyGrassBlock>().AsSingle();
            Container.Bind<IBlock>().To<DirtBlock>().AsSingle();
            Container.Bind<IBlock>().To<CoarseDirtBlock>().AsSingle();
            Container.Bind<IBlock>().To<ClayBlock>().AsSingle();
            Container.Bind<IBlock>().To<GravelBlock>().AsSingle();
            Container.Bind<IBlock>().To<SandBlock>().AsSingle();

            Container.Bind<IBlock>().To<SandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedSandBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedSandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<IceBlock>().AsSingle();
            Container.Bind<IBlock>().To<PackedIceBlock>().AsSingle();
            Container.Bind<IBlock>().To<SnowBlock>().AsSingle();
            Container.Bind<IBlock>().To<StoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<GraniteBlock>().AsSingle();

            Container.Bind<IBlock>().To<DioriteBlock>().AsSingle();
            Container.Bind<IBlock>().To<AndesiteBlock>().AsSingle();
            Container.Bind<IBlock>().To<PrismarineBlock>().AsSingle();
            Container.Bind<IBlock>().To<ObsidianBlock>().AsSingle();
            Container.Bind<IBlock>().To<NetherrackBlock>().AsSingle();
            Container.Bind<IBlock>().To<SoulSandBlock>().AsSingle();
            Container.Bind<IBlock>().To<GlowstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<CoalOreBlock>().AsSingle();

            Container.Bind<IBlock>().To<IronOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<GoldOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedstoneOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<LapisOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<EmeraldOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<DiamondOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<OakLogBlock>().AsSingle();
            Container.Bind<IBlock>().To<SpruceLogBlock>().AsSingle();

            Container.Bind<IBlock>().To<BirchLogBlock>().AsSingle();
            Container.Bind<IBlock>().To<JungleLogBlock>().AsSingle();
            Container.Bind<IBlock>().To<AcaciaLogBlock>().AsSingle();
            Container.Bind<IBlock>().To<DarkOakLogBlock>().AsSingle();
            Container.Bind<IBlock>().To<OakLeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<SpruceLeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<BirchLeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<JungleLeavesBlock>().AsSingle();

            Container.Bind<IBlock>().To<AcaciaLeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<DarkOakLeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<OakSaplingBlock>().AsSingle();
            Container.Bind<IBlock>().To<SpruceSaplingBlock>().AsSingle();
            Container.Bind<IBlock>().To<BirchSaplingBlock>().AsSingle();
            Container.Bind<IBlock>().To<JungleSaplingBlock>().AsSingle();
            Container.Bind<IBlock>().To<AcaciaSaplingBlock>().AsSingle();
            Container.Bind<IBlock>().To<DarkOakSaplingBlock>().AsSingle();

            Container.Bind<IBlock>().To<BushBlock>().AsSingle();
            Container.Bind<IBlock>().To<PoppyBlock>().AsSingle();
            Container.Bind<IBlock>().To<DandelionBlock>().AsSingle();
            Container.Bind<IBlock>().To<AlliumBlock>().AsSingle();
            Container.Bind<IBlock>().To<AzureBlock>().AsSingle();
            Container.Bind<IBlock>().To<BlueOrchidBlock>().AsSingle();
            Container.Bind<IBlock>().To<OxeyeDaisyBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedMushroomBlock>().AsSingle();

            Container.Bind<IBlock>().To<BrownMushroomBlock>().AsSingle();
            Container.Bind<IBlock>().To<SpongeBlock>().AsSingle();
            Container.Bind<IBlock>().To<WetSpongeBlock>().AsSingle();
            Container.Bind<IBlock>().To<MelonBlock>().AsSingle();
            Container.Bind<IBlock>().To<PumpkinBlock>().AsSingle();
            Container.Bind<IBlock>().To<JackOLanternBlock>().AsSingle();
            Container.Bind<IBlock>().To<HayBaleBlock>().AsSingle();
            Container.Bind<IBlock>().To<BedrockBlock>().AsSingle();

            Container.Bind<IBlock>().To<OakPlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<SprucePlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<BirchPlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<JunglePlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<AcaciaPlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<DarkOakPlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<CobblestoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<MossCobblestoneBlock>().AsSingle();

            Container.Bind<IBlock>().To<StoneBrickBlock>().AsSingle();
            Container.Bind<IBlock>().To<CrackedStoneBrickBlock>().AsSingle();
            Container.Bind<IBlock>().To<ChiseledStoneBrickBlock>().AsSingle();
            Container.Bind<IBlock>().To<MossStoneBrickBlock>().AsSingle();
            Container.Bind<IBlock>().To<PolishedGraniteBlock>().AsSingle();
            Container.Bind<IBlock>().To<PolishedDioriteBlock>().AsSingle();
            Container.Bind<IBlock>().To<PolishedAndesiteBlock>().AsSingle();
            Container.Bind<IBlock>().To<BrickBlock>().AsSingle();

            Container.Bind<IBlock>().To<CutSandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<ChiseledSandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedCutSandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedChiseledSandstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<SeaLanternBlock>().AsSingle();
            Container.Bind<IBlock>().To<DarkPrismarineBlock>().AsSingle();
            Container.Bind<IBlock>().To<PrismarineBricksBlock>().AsSingle();
            Container.Bind<IBlock>().To<CoalBlock>().AsSingle();

            Container.Bind<IBlock>().To<IronBlock>().AsSingle();
            Container.Bind<IBlock>().To<GoldBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedstoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<LapisBlock>().AsSingle();
            Container.Bind<IBlock>().To<EmeraldBlock>().AsSingle();
            Container.Bind<IBlock>().To<DiamondBlock>().AsSingle();
            Container.Bind<IBlock>().To<CraftingBenchBlock>().AsSingle();
            Container.Bind<IBlock>().To<FurnaceBlock>().AsSingle();

            Container.Bind<IBlock>().To<NoteBlock>().AsSingle();
            Container.Bind<IBlock>().To<JukeboxBlock>().AsSingle();
            Container.Bind<IBlock>().To<LadderBlock>().AsSingle();
            Container.Bind<IBlock>().To<BookshelfBlock>().AsSingle();
            Container.Bind<IBlock>().To<MobSpawnerBlock>().AsSingle();
            Container.Bind<IBlock>().To<TNTBlock>().AsSingle();
            Container.Bind<IBlock>().To<WhiteWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<LightGreyWoolBlock>().AsSingle();

            Container.Bind<IBlock>().To<GreyWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<BlackWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<BrownWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<RedWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<OrangeWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<YellowWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<LimeWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<GreenWoolBlock>().AsSingle();

            Container.Bind<IBlock>().To<CyanWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<LightBlueWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<BlueWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<PurpleWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<MagentaWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<PinkWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<Terracotta>().AsSingle();
            Container.Bind<IBlock>().To<WhiteTerracotta>().AsSingle();

            Container.Bind<IBlock>().To<LightGreyTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<GreyTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<BlackTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<BrownTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<RedTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<OrangeTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<YellowTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<LimeTerracotta>().AsSingle();

            Container.Bind<IBlock>().To<GreenTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<CyanTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<LightBlueTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<BlueTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<PurpleTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<MagentaTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<PinkTerracotta>().AsSingle();
            Container.Bind<IBlock>().To<GlassBlock>().AsSingle();

            Container.Bind<IBlock>().To<WhiteStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<LightGreyStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<GreyStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<BlackStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<BrownStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<RedStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<OrangeStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<YellowStainedGlass>().AsSingle();

            Container.Bind<IBlock>().To<LimeStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<GreenStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<CyanStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<LightBlueStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<BlueStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<PurpleStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<MagentaStainedGlass>().AsSingle();
            Container.Bind<IBlock>().To<PinkStainedGlass>().AsSingle();

            Container.Bind<IBlock>().To<OakStairsBlock>().AsSingle();
        }
    }
}
