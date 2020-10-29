/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using WpfApp2;

namespace Class_diagram.Service
{
    public class EquipmentService : bingPath, IService<Equipment>
    {
        public RoomRepository roomRepository;
        public EquipmentRepository equipmentRepository;
        String path = bingPathToAppDir(@"JsonFiles\equipment.json");
        String path2 = bingPathToAppDir(@"JsonFiles\room.json");

        public EquipmentService()
        {
            equipmentRepository = new EquipmentRepository(path);
            roomRepository = new RoomRepository(path2);
        }

        public Boolean isNameValid(String name)
        {
            List<Equipment> listOfEquipments = GetAll();

            foreach (Equipment equipment in listOfEquipments)
            {
                if (equipment.Name.ToLower().Equals(name.ToLower()))
                {
                    return false;
                }
            }

            return true;
        }


        private void addEquipmentIfRoomIsStorage(Equipment equipment, Room room)
        {
            if (room.TypeOfRoom.Equals("Magacin"))
            {
                equipment.room.Add(room.TypeOfRoom);
                room.equipment.Add(equipment.Name);
                roomRepository.Update(room);
            }
        }

        private void addEquipmentInStorages(Equipment equipment)
        {
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                addEquipmentIfRoomIsStorage(equipment, room);
            }
        }

        public void New(Equipment equipment)
        {
            addEquipmentInStorages(equipment);
            equipmentRepository.New(equipment);
        }

        public void Update(Equipment equipment)
        {
            equipmentRepository.Update(equipment);
        }

        private void deleteIfEquipmentsEqual(Equipment firstEquipment, Equipment secondEquipment)
        {
            if (firstEquipment.ID == secondEquipment.ID)
            {
                equipmentRepository.Delete(firstEquipment.ID);

            }

        }
        public void Remove(Equipment equipment)
        {
            List<Equipment> listOfEquipments = equipmentRepository.GetAll();

            foreach (Equipment equipmentIt in listOfEquipments)
            {
                deleteIfEquipmentsEqual(equipmentIt, equipment);
            }
            removeEquipmentFromAllRooms(equipment);
        }

        private void removeEquipmentFromSpecificRoom(Equipment equipment, Room room)
        {
            if (room.equipment.Contains(equipment.Name))
            {
                room.equipment.Remove(equipment.Name);
                roomRepository.Update(room);
            }
        }



        public void removeEquipmentFromAllRooms(Equipment equipment)
        {
           
            List<Room> listOfRooms = new List<Room>();
            listOfRooms = roomRepository.GetAll();

            foreach (Room room in listOfRooms)
            {
                removeEquipmentFromSpecificRoom(equipment,room);
            }

        }
      
        public List<Equipment> GetAll()
        {
           return equipmentRepository.GetAll();

        }

        public Equipment GetByID(int ID)
        {
            return equipmentRepository.GetByID(ID);
        }
    }
}