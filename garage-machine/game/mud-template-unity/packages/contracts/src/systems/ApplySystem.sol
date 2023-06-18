// SPDX-License-Identifier: MIT
pragma solidity >=0.8.0;

import { System } from "@latticexyz/world/src/System.sol";
import { Garage, Tenant, Position} from "../codegen/Tables.sol";
import { LibUtils } from "../libraries/LibUtils.sol";

contract ApplySystem is System {
  
  function doApplication(uint32 x, uint32 y) public {
    
    bytes32 entity = LibUtils.addressToEntityKey(address(_msgSender()));
    require(!Garage.get(entity), "already joined");
    
    Garage.set(entity, true);
    Position.set(entity, x, y);

  }

}