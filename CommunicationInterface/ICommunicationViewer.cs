using System;
namespace Communication.Interface
{
    public interface ICommunicationViewer
    {
        ICommunicationViewer AddDisplayFilter(string Source, string Target);
        void AttachInterface(Communication.Interface.ICommunicationInterface CommunicationInterface, bool ClearPrevious = true);
        void ClearDisplayFilter();
        void DeattachInterface(Communication.Interface.ICommunicationInterface CommunicationInterface);
        void HideViewer();
        void Release();
        void Save(string FriendlyName, string FileName, bool Overwrite);
        void ShowViewer();
    }
}
