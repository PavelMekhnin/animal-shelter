import React from 'react';
import { IVolunteerCard } from '../interfaces/Interfaces';
import { VolunteerCardPreview } from './VolunteerCardPreview';

type VolunteerList = {
    list: IVolunteerCard[]
}

export const VolunteerCardList = (data : VolunteerList) => {
    var exists = data.list != null && data.list.length > 0;
    return (
        <>
            <div className="shelter-profile_tabs_tab">       
            <div className="row">
                <h5 className="center-align orange-text">Our volunteers</h5>
            </div>         
                {exists ?
                data.list.map(card => {
                    return (
                        <VolunteerCardPreview card={card}></VolunteerCardPreview>
                    )
                })
                : <p>We do not have any volunteers yet ;(</p>
                }
            </div>
        </>
    )
}