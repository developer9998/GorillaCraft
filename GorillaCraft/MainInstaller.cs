using GorillaCraft.Behaviours;
using GorillaCraft.Blocks;
using GorillaCraft.Factories;
using GorillaCraft.Interfaces;
using GorillaLocomotion;
using System;
using UnityEngine;
using Zenject;

namespace GorillaCraft
{
    public class MainInstaller : Installer
    {
        public GameObject Player => UnityEngine.Object.FindObjectOfType<Player>().gameObject;

        public override void InstallBindings()
        {
            Container.BindFactory<Type, IDataType, BlockDataFactory_PL>().FromFactory<BlockDataFactory>();

            Container.BindInterfacesAndSelfTo<Main>().FromNewComponentOn(Player).AsSingle();

            Container.Bind<BlockHandler>().FromNewComponentOn(Player).AsSingle();
            Container.Bind<PlacementHelper>().FromNewComponentOn(Player).AsSingle();

            Container.Bind<AssetLoader>().AsSingle();

            Container.Bind<IBlock>().To<StoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<CobblestoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<BrickBlock>().AsSingle();
            Container.Bind<IBlock>().To<DirtBlock>().AsSingle();
            Container.Bind<IBlock>().To<GrassBlock>().AsSingle();
            Container.Bind<IBlock>().To<PlanksBlock>().AsSingle();
            Container.Bind<IBlock>().To<LogBlock>().AsSingle();
            Container.Bind<IBlock>().To<LeavesBlock>().AsSingle();
            Container.Bind<IBlock>().To<GlassBlock>().AsSingle();

            Container.Bind<IBlock>().To<MossCobblestoneBlock>().AsSingle();
            Container.Bind<IBlock>().To<SandBlock>().AsSingle();
            Container.Bind<IBlock>().To<GravelBlock>().AsSingle();
            Container.Bind<IBlock>().To<SpongeBlock>().AsSingle();
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
            Container.Bind<IBlock>().To<BlackWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<LightGreyWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<GreyWoolBlock>().AsSingle();

            Container.Bind<IBlock>().To<WhiteWoolBlock>().AsSingle();
            Container.Bind<IBlock>().To<CoalOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<IronOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<GoldOreBlock>().AsSingle();
            Container.Bind<IBlock>().To<IronBlock>().AsSingle();
            Container.Bind<IBlock>().To<GoldBlock>().AsSingle();
            Container.Bind<IBlock>().To<BookshelfBlock>().AsSingle();
            Container.Bind<IBlock>().To<TNTBlock>().AsSingle();
            Container.Bind<IBlock>().To<ObsidianBlock>().AsSingle();
        }
    }
}
