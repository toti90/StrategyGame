export interface IInitialInfosDTO {
  round: number;
  place: number;
  userName: string;
  legions: ILegion[];
  storage: IStorage;
  buildingGorups: IBuildingGroup[];
  pearlPerROund: number;
  coralPerRound: number;
}

export interface ILegion {
  unitId: number;
  amount: number;
  imageUrl: string;
}

export interface IBuildingGroup {
  buildingId: number;
  smallImageUrl: string;
  bigImageUrl: string;
  amount: number;
  inProgress: boolean;
}

export interface IStorage {
  pearl: number;
  coral: number;
}
