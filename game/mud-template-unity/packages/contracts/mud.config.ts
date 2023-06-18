import { mudConfig, resolveTableId } from "@latticexyz/world/register";

export default mudConfig({
  overrideSystems: {
    IncrementSystem: {
      name: "increment",
      openAccess: true,
    },
  },
  tables: {
    Counter: {
      schema: {
        value: "uint32",
      },
      storeArgument: true,
    },
    Garage: {
      schema: {
        isOccupied: "bool",
      },
      storeArgument: true,
    },
    Tenant: {
      schema: {
        garageAddress: "address",
      },
      storeArgument: true,
    },
    Position: {
      keySchema: {
        entity: "bytes32",
      },
      schema: {
        x: "uint32",
        y: "uint32",
      },
      dataStruct: false,
    },
    Cluster: {
      schema: {
        id: "uint32",
      },
      storeArgument: true,
    },
  },
  modules: [
    {
      name: "KeysWithValueModule",
      root: true,
      args: [resolveTableId("Counter")],
    },
  ],
});
