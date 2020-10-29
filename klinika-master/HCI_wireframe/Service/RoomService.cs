/***********************************************************************
 * Module:  EquipmentService.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EquipmentService
 ***********************************************************************/

using Class_diagram.Contoller;
using Class_diagram.Model.Employee;
using Class_diagram.Model.Hospital;
using Class_diagram.Repository;
using HCI_wireframe.Service;
using System;
using System.Collections.Generic;
using System.IO;

namespace Class_diagram.Service
{
   public class RoomService : bingPath, IService<Room>
    {
        String path = bingPathToAppDir(@"JsonFiles\room.json");
        String path2 = bingPathToAppDir(@"JsonFiles\medicine.json");
        String path3 = bingPathToAppDir(@"JsonFiles\equipment.json");

        public RoomRepository roomRepository;
        public MedicineRepository medicineRepository;
        public EquipmentRepository equipmentRepository;

        public RoomService()
        {
            roomRepository = new RoomRepository(path);
            medicineRepository = new MedicineRepository(path2);
            equipmentRepository = new EquipmentRepository(path3);
        }

        
        public Boolean isNameValid(String name)
        {
            List<Room> listOfRooms = GetAll();

            foreach (Room room in listOfRooms)
            {
                if (room.TypeOfRoom.ToLower().Equals(name.ToLower()))
                {
                    return false;
                }
            }
            
            return true;
        }

        public void New(Room room)
      {
           
            roomRepository.New(room);
        }
      
      public void Update(Room room)
      {
            roomRepository.Update(room);
        }
      
      public void Remove(Room room)
      {
            removeRoomFromAllMedicines(room);

            removeRoomFromAllEquipments(room);

            removeRoomFromAllSchedules(room);
            
            roomRepository.Delete(room.ID);
        }


        //MEDICINE
        private Boolean isMedicineInRoom(Medicine medicine, Room room)
        {
            
            if(medicine.room.Contains(room.TypeOfRoom))
            {
                return true;
            }
            return false;
        }

        private void removeRoomFromMedicine(Medicine medicine, Room room)
        {
            if (isMedicineInRoom(medicine, room))
            {
                
                medicine.room.Remove(room.TypeOfRoom);
                medicineRepository.Update(medicine);

               
            }
        }


        public void removeRoomFromAllMedicines(Room room)
        {
            List<Medicine> listOfMedicines = new List<Medicine>();
            listOfMedicines = medicineRepository.GetAll();

            foreach (Medicine medicine in listOfMedicines)
            {

                removeRoomFromMedicine(medicine, room);
            }
        }


        //EQUIPMENT
        private Boolean isEquipmentInRoom(Equipment equipment, Room room)
        {

            if (equipment.room.Contains(room.TypeOfRoom))
            {
                return true;
            }
            return false;
        }

        private void removeRoomFromEquipment(Equipment equipment, Room room)
        {
            if (isEquipmentInRoom(equipment, room))
            {

                equipment.room.Remove(room.TypeOfRoom);
                equipmentRepository.Update(equipment);


            }
        }

        public void removeRoomFromAllEquipments(Room room)
        {
            List<Equipment> listOfEquipments = new List<Equipment>();
            listOfEquipments = equipmentRepository.GetAll();

            foreach (Equipment equipment in listOfEquipments)
            {
                removeRoomFromEquipment(equipment, room);
            }
        }


        //SCHEDULE
        private Boolean isScheduleForRoom(Schedule schedule, Room room)
        {

            if (schedule.soba.Equals(room.TypeOfRoom))
            {
                return true;
            }
            return false;
        }

     

        public void removeRoomFromAllSchedules(Room room)
        {
            EmployeesScheduleController employeesScheduleController = new EmployeesScheduleController();
            List<Schedule> listOfSchedules = new List<Schedule>();
            listOfSchedules = employeesScheduleController.GetAll();

            foreach (Schedule schedule in listOfSchedules)
            {

                if (isScheduleForRoom(schedule, room))
                {
                    //UPDATE?
                    employeesScheduleController.Remove(schedule);
                }
            }

        }

        public List<Room> GetAll()
        {
            return roomRepository.GetAll();
        }

        public Room GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}