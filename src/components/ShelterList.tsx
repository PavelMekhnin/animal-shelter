import React from "react";
import { IShelterCardPreview } from "../interfaces/Interfaces";
import { ShelterCardPreview } from "./ShelterCardPreview";

type ShelterListData = {
    list: IShelterCardPreview[]
}

export const ShelterList: React.FC = () => {

    const listData: ShelterListData = {
        list: [{
            addres: "adres",
            animal_count: 76,
            id: 1,
            logo_url: "",
            title: "Chance",
            volunteer_count: 12
        }]
    }

    return (
        <div className="container">
            <div className="row">
                <input type="search" name="" id="search" />
            </div>
            <div className="row">
                    {
                        listData.list.map(x => {
                            return (
                                <ShelterCardPreview card={x}></ShelterCardPreview>
                            )
                        })
                    }
            </div>
        </div>
    )
}